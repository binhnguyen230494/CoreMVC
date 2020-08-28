using CoreMVCViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCAdminApp.Models.Service
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}
