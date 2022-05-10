namespace WarehouseManagementDesktopApp.Core.Domain.Model.API.Storage;

public class UpdateSliceItem
{
    public string shelfId { get; set; }
    public int rowId { get; set; }
    public int cellId { get; set; }
    public int slices { get; set; }
    public string itemid { get; set; }
}
