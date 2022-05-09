using WarehouseManagementDesktopApp.Core.Domain.Communication;
using WarehouseManagementDesktopApp.Core.Domain.Model;
using WarehouseManagementDesktopApp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Services
{
    public class UserManagerService :IUserManagerService
    {
        public event Action<string> LoginHandlers;
        private readonly IApiService _apiService;
        private Manager user;

        public UserManagerService (IApiService apiService)
        {
            this._apiService = apiService;
        }    
        public Manager GetUser()
        {
            return user;
        }
        public async Task<ServiceResponse> Login(string username, string password)
        {
            //var result = await _apiService.LogInAsync(username, password);
            //if (result.Success)
            //{
            //    user = result.Resource;
            //    LoginHandlers?.Invoke(user.lastName);
            //    return ServiceResponse.Successful();
            //}
            //else
            //{
            //    return ServiceResponse.Failed(result.Error);
            //}
            return ServiceResponse.Successful();
        }
        public void Logout()
        {
            user = null;
            _apiService.LogOut();
        }
    }
}
