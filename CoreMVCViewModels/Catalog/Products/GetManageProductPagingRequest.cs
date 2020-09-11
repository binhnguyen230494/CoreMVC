using CoreMVCViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMVCViewModels.Catalog.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public int? CategoryId { set; get; }
        public string LanguageId { get; set; }
    }
}
