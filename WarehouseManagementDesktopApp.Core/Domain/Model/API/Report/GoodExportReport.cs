using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model.API.Report;

public class GoodExportReport
{
    public List<ItemOfGoodExport> items { get; set; }
    public int totalItems { get; set; }
}
public class ItemOfGoodExport
{
    public string goodsIssueId { get; set; }
    public DateTime timestamp { get; set; }
    public bool confirmed { get; set; }
    public List<EntryOfGoodExportReport> entries { get; set; }
}
public class EntryOfGoodExportReport
{
    public Manager employee { get; set; }
    public Product item { get; set; }
    public int totalQuantity { get; set; }
    public List<ContainerOfGoodExportReport> containers { get; set; }
    public string note { get; set; }
}
public class ContainerOfGoodExportReport
{
    public string containerId { get; set; }
    public double quantity { get; set; }
    public bool  isTaken { get; set; }
    public DateTime productionDate { get; set; }
}

