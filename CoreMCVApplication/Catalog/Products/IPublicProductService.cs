using CoreMVCViewModels.Catalog.Products;
using CoreMVCViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreMCVApplication.Catalog.Products
{
    public interface IPublicProductService
    {
       Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request);
       Task<List<ProductViewModel>> GetAll();
    }
}
