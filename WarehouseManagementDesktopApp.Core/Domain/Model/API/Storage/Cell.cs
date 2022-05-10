namespace WarehouseManagementDesktopApp.Core.Domain.Model.API.Storage;

public class Cell
{
    public int rowId { get; set; }
    public int id { get; set; }
    public List<Slice>? slices { get; set; }
}
