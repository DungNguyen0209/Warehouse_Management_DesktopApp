using Slot = WarehouseManagementDesktopApp.Core.Domain.Model.API.Storage.Slot;
namespace WarehouseManagementDesktopApp.Core.Domain.Model.API.Containers;

public class Container
{
#pragma warning disable CS8618
    public string containerId { get; set; }
    public double plannedQuantity { get; set; }
    public double actualQuantity { get; set; }
    public DateTime productionDate { get; set; }
    public bool consistent { get; set; }
    public Product item { get; set; }
    public Location location { get; set; }
    public ContainerType containerType { get; set; } 

#pragma warning restore
}
