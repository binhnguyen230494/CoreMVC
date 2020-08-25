
using CoreMCVData.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CoreMVCViewModels.Catalog.Products;
using CoreMVCViewModels.Common;
using CoreMCVApplication.Common;

namespace CoreMCVApplication.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly CoreMVCDbContext _coreMVCDbContext;
        
        public PublicProductService(CoreMVCDbContext context)
        {
            _coreMVCDbContext = context;
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            var query = from p in _coreMVCDbContext.Products
                        join pt in _coreMVCDbContext.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _coreMVCDbContext.ProductInCategories on p.Id equals pic.ProductId
                        join c in _coreMVCDbContext.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };
            var data = await query.Select(x=> new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    Description = x.pt.Description,
                    DateCreated = x.p.DateCreated,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();
            return data;
        }

        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request)
        {
            var query = from p in _coreMVCDbContext.Products
                        join pt in _coreMVCDbContext.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _coreMVCDbContext.ProductInCategories on p.Id equals pic.ProductId
                        join c in _coreMVCDbContext.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };
            
            if (request.CategoryId.HasValue && request.CategoryId.Value >0)
            {

                query.Where(p => p.pic.CategoryId == request.CategoryId);
            }
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    Description = x.pt.Description,
                    DateCreated = x.p.DateCreated,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }
    }
}
