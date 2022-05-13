namespace WarehouseManagementDesktopApp.Core.Domain.Model.API.Containers;

public class Location
{
    public string shelfId { get; set; }
    public int rowId { get; set; }
    public int cellId { get; set; }
    public int sliceId { get; set; }
    public int levelId { get; set; }
    public int id { get; set; }
}
