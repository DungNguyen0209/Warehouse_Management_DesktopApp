using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model.API.Report;

public class GoodReceiptReport
{
    public List<ItemOfGoodReceipt> items { get; set; }
    public int totalItems { get; set; }
}
public class ItemOfGoodReceipt
{
    public string goodsReceiptId { get; set; }
    public DateTimeOffset timestamp { get; set; }
    public Manager approver { get; set; }
    public List<EntryOfGoodReceiptReport> entries { get; set; }
    public bool confirmed { get; set; }
}
public class EntryOfGoodReceiptReport
{
    public int itemId { get; set; }
    public Product item { get; set; }
    public int plannedQuantity { get; set; }
    public List<ContainerOfGoodReceiptReport> containers { get; set; }
    public string note { get; set; }
}
public class ContainerOfGoodReceiptReport
{
    public string containerId { get; set; }
    public double plannedQuantity { get; set; }
    public double actualQuantity { get; set; }
    public DateTime productionDate { get; set; }
}


