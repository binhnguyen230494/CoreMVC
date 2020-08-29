using CoreMVCViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMVCViewModels.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    { 
        public int? CategoryId { get; set; }
    }
}
