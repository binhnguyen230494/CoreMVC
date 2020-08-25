using System.Linq;
using CoreMCVData.EF;
using CoreMCVData.Entites;
using CoreMVCUtilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreMVCViewModels.Common;
using CoreMVCViewModels.Catalog.Products;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using CoreMCVApplication.Common;
using CoreMVCViewModels.Catalog.ProductImages;

namespace CoreMCVApplication.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly CoreMVCDbContext _coreMVCDbContext;
        private readonly IStorageService _storageService;
        public ManageProductService(CoreMVCDbContext context, IStorageService storageService)
        {
            _coreMVCDbContext = context;
            _storageService = storageService;
        }

        public Task<int> AddImages(int productID, List<IFormFile> files)
        {
            throw new NotImplementedException();
        }

        public async Task AddViewcount(int productId)
        {
            var product = await _coreMVCDbContext.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _coreMVCDbContext.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name=request.Name,
                        Description =request.Description,
                        Details =request.Details,
                        SeoDescription =request.SeoDescription,
                        SeoAlias =request.SeoAlias,
                        SeoTitle =request.SeoTitle,
                        LanguageId =request.LanguageId

                    }
                }
            };
            if (request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "Thumbnail image",
                        DateCreated = DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImagePath = await this.SaveFile(request.ThumbnailImage),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }
            _coreMVCDbContext.Products.Add(product);
            await _coreMVCDbContext.SaveChangesAsync();
            return product.Id;
        }

        public async Task<int> Delete(int productID)
        {
            var product = await _coreMVCDbContext.Products.FindAsync(productID);
            if (product == null) throw new MVCException($"Cannot find a product: {productID}");

            var images = _coreMVCDbContext.ProductImages.Where(i => i.ProductId == productID);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
            }

            _coreMVCDbContext.Products.Remove(product);

            return await _coreMVCDbContext.SaveChangesAsync();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {
            var query = from p in _coreMVCDbContext.Products
                        join pt in _coreMVCDbContext.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _coreMVCDbContext.ProductInCategories on p.Id equals pic.ProductId
                        join c in _coreMVCDbContext.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            if(request.CategoryIds.Count > 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
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
            var pagedResult =  new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<ProductImageViewModel> GetImageById(int imageId)
        {
            var image = await _coreMVCDbContext.ProductImages.FindAsync(imageId);
            if (image == null)
                throw new MVCException($"Cannot find an image with id {imageId}");

            var viewModel = new ProductImageViewModel()
            {
                Caption = image.Caption,
                DateCreated = image.DateCreated,
                FileSize = image.FileSize,
                Id = image.Id,
                ImagePath = image.ImagePath,
                IsDefault = image.IsDefault,
                ProductId = image.ProductId,
                SortOrder = image.SortOrder
            };
            return viewModel;
        }

        public async Task<List<ProductImageViewModel>> GetListImages(int productId)
        {
            return await _coreMVCDbContext.ProductImages.Where(x => x.ProductId == productId)
                .Select(i => new ProductImageViewModel()
                {
                    Caption = i.Caption,
                    DateCreated = i.DateCreated,
                    FileSize = i.FileSize,
                    Id = i.Id,
                    ImagePath = i.ImagePath,
                    IsDefault = i.IsDefault,
                    ProductId = i.ProductId,
                    SortOrder = i.SortOrder
                }).ToListAsync();
        }
        public async Task<int> RemoveImages(int imageId)
        {
            var productImage = await _coreMVCDbContext.ProductImages.FindAsync(imageId);
            if (productImage == null)
                throw new MVCException($"Cannot find an image with id {imageId}");
            _coreMVCDbContext.ProductImages.Remove(productImage);
            return await _coreMVCDbContext.SaveChangesAsync();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = _coreMVCDbContext.Products.FindAsync(request.Id);
            var productTranslations = await _coreMVCDbContext.ProductTranslations.FirstOrDefaultAsync
                (x => x.ProductId == request.Id && x.LanguageId == request.LanguageId);
            if (product == null || productTranslations ==null) throw new MVCException($"khong tim thhay:{request.Id}");
            productTranslations.Name = request.Name;
            productTranslations.SeoAlias = request.SeoAlias;
            productTranslations.SeoDescription = request.SeoDescription;
            productTranslations.SeoTitle = request.SeoTitle;
            productTranslations.Details = request.Details;
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _coreMVCDbContext.ProductImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == request.Id);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _coreMVCDbContext.ProductImages.Update(thumbnailImage);
                }
            }

            return await _coreMVCDbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request)
        {
            var productImage = await _coreMVCDbContext.ProductImages.FindAsync(imageId);
            if (productImage == null)
                throw new MVCException($"Cannot find an image with id {imageId}");

            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _coreMVCDbContext.ProductImages.Update(productImage);
            return await _coreMVCDbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _coreMVCDbContext.Products.FindAsync(productId);
            if (product == null) throw new MVCException($"Khong tim thay: {productId}");
            product.Price = newPrice;
            return await _coreMVCDbContext.SaveChangesAsync() > 0;
            

        }

        public async Task<bool> UpdateStock(int productId, int addQuantily)
        {
            var product = await _coreMVCDbContext.Products.FindAsync(productId);
            if (product == null) throw new MVCException($"Khong tim thay: {productId}");
            product.Price += addQuantily;
            return await _coreMVCDbContext.SaveChangesAsync() > 0;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

    }
}
