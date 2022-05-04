using Slot = WarehouseManagementDesktopApp.Core.Domain.Model.API.Storage.Slot;
namespace WarehouseManagementDesktopApp.Core.Domain.Model.API.Containers;

public class Container
{
#pragma warning disable CS8618
    public string id { get; set; }
    public double plannedQuantity { get; set; }
    public double actualQuantity { get; set; }
    public DateTime productionDate { get; set; }
    public Item item { get; set; }
    public Slot location { get; set; }
    public ContainerType containerType { get; set; } 

#pragma warning restore
}
