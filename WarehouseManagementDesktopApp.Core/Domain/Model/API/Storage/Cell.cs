namespace WarehouseManagementDesktopApp.Core.Domain.Model.API.Storage;

public class Cell
{
    public int row { get; set; }
    public int column { get; set; }
    public List<Slice>? slices { get; set; }
}
