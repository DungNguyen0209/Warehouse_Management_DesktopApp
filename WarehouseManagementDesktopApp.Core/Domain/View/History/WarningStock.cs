using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.View.History;

public class WarningStock
{
    public string Id { get; set; }
    public string itemId { get; set; }
    public string name { get; set; }
    public string minimumStockLevel { get; set; }
    public string maximumStockLevel { get; set; }
    public string unit { get; set; }
    public double afterQuantity { get; set; }
}
