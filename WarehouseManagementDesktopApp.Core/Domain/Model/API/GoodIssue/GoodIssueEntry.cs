namespace WarehouseManagementDesktopApp.Core.Domain.Model.API.GoodIssue;
public class GoodIssueEntry
{
    public string goodsIssueId { get; set; }
    public string timestamp { get; set; }
    public List<ProductEntry> entries { get; set; }
}
public class ProductEntry
{
    public string itemId { get; set; }
    public double TotalQuantity { get; set; }
    public string note { get; set; }
}

