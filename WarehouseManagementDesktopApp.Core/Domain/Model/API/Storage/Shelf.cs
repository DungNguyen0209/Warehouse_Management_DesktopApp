namespace WarehouseManagementDesktopApp.Core.Domain.Model.API.Storage;

public  class Shelf
{
    public string shelfId { get; set; }
    public int priority { get; set; }
    public List<Cell> cells { get; set; }
}
