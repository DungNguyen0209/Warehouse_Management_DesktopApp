using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model.API.GoodIssue;

public class GoodIssueFromServer
{
    public List<GoodIssueItems> items { get; set; }
    public int totalItems { get; set; }
}
public class GoodIssueItems
{
    public string goodsIssueId { get; set; }
    public DateTime timestamp { get; set; }
    public bool confirmed { get; set; }
    public List<GoodIssueItemEntry> entries { get; set; }
}
public class GoodIssueItemEntry
{
    public Manager employee { get; set; }
    public NewProduct item { get; set; }
    public int totalQuantity { get; set; }
    public List<object> containers { get; set; }
    public string note { get; set; }
}
