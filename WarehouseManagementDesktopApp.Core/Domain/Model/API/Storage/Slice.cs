namespace WarehouseManagementDesktopApp.Core.Domain.Model.API.Storage;

public class Slice
{
    public int id { get; set; }
    public Product item { get; set; }
    public List<Slot> slots { get; set; }
}
