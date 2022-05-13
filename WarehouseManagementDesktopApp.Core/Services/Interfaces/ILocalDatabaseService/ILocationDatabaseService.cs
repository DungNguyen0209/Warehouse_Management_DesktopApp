using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementDesktopApp.Core.Domain.Model.API.Containers;

namespace WarehouseManagementDesktopApp.Core.Services.Interfaces.ILocalDatabaseService;

public interface ILocationDatabaseService
{
    Task<ServiceResponse> Delete();
    Task<ServiceResponse> AddItemLocation(List<Location> container);
    Task<ServiceResourceResponse<ContainerLocation>> LoadDatabase(int Id);
}
