using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model.API;

public class GoodReceiptEntry
{
    public string goodsReceiptId { get; set; }
    public string timestamp { get; set; }
    public string approverId { get; set; }
    public List<EntryOfGoodReceipt> entries { get; set; }
}
public class EntryOfGoodReceipt
{
    public string itemId { get; set; }
    public double TotalQuantity { get; set; }
}
