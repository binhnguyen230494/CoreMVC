using CoreMCVData.EF;
using CoreMVCViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CoreMVCViewModels.Common;

namespace CoreMCVApplication.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly CoreMVCDbContext _context;
        public CategoryService(CoreMVCDbContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryVm>> GetAll(string languageId)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name
            }).ToListAsync();
        }
    }
}
