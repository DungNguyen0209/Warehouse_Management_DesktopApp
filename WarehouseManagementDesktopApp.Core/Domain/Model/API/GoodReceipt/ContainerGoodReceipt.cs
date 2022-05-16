namespace WarehouseManagementDesktopApp.Core.Domain.Model.API.GoodReceipt;

public class ContainerGoodReceipt
{
    public string containerId { get; set; }
    public string itemId { get; set; }
    public double plannedQuantity { get; set; }
    public double actualQuantity { get; set; }
    public string productionDate { get; set; }
}
