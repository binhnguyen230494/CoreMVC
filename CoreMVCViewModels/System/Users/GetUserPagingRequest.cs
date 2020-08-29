using CoreMVCViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMVCViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
