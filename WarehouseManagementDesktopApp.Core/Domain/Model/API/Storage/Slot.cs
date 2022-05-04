using Container = WarehouseManagementDesktopApp.Core.Domain.Model.API.Containers.Container;
namespace WarehouseManagementDesktopApp.Core.Domain.Model.API.Storage;

public  class Slot
{
    public int id { get; set; }
    public Container? container { get; set; }
}
