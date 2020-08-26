using CoreMVCViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMVCViewModels.Catalog.Products
{
    public class GetProductPagingRequest : PagingRequestBase
    { 
        public int? CategoryId { get; set; }
    }
}
