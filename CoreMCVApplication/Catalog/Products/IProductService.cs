using CoreMCVApplication.Catalog.Products;
using CoreMVCViewModels.Catalog.ProductImages;
using CoreMVCViewModels.Catalog.Products;
using CoreMVCViewModels.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreMCVApplication.Catalog.Products
{
    public interface IProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<ApiResult<int>> Delete(int productID);
        Task<ProductVm> GetById(int productId, string languageId);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addQuantily);
        Task AddViewcount(int productId);
        Task<PagedResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request);
        Task<int> AddImages(int productID, ProductImageCreateRequest request);
        Task<int> RemoveImages(int imageId);
        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);
        Task<ProductImageViewModel> GetImageById(int imageId);

        Task<List<ProductImageViewModel>> GetListImages(int productId);

        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);
        Task<PagedResult<ProductVm>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);
        
    }
}
