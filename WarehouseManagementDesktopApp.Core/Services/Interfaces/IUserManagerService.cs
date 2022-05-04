
using WarehouseManagementDesktopApp.Core.Domain.Communication;
using WarehouseManagementDesktopApp.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Services.Interfaces
{
    public interface IUserManagerService
    {
        Task<ServiceResponse> Login(string username, string password);


        void Logout();


        WarehouseEmployee GetUser();


        event Action<string> LoginHandlers;


    }
}
