namespace WarehouseManagementDesktopApp.Core.Domain.Model.API.GoodIssue;
public class GoodIssueEntry
{
    public string goodsReceiptId { get; set; }
    public string timestamp { get; set; }
    public string? approverId { get; set; }
    public List<ProductEntry> entries { get; set; }
}
public class ProductEntry
{
    public string itemId { get; set; }
    public int TotalQuantity { get; set; }
}

