namespace WarehouseManagementDesktopApp.Core.Domain.Model.API.Storage;

public class Slice
{
    public int id { get; set; }
    public Product? product { get; set; }
    public List<SliceLevel>? levels  { get; set; }
}
