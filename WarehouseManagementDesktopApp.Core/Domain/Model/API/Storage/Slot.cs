namespace WarehouseManagementDesktopApp.Core.Domain.Model.API.Storage;

public  class Slot
{
    // levelId= heightid
    public int levelId { get; set; }
    // id = depthid
    public int id { get; set; }
    public string containerId { get; set; }
    public Container? container { get; set; }
}
