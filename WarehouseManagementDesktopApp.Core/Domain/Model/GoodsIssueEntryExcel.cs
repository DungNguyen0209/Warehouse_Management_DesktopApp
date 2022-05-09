using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model
{
    public class GoodsIssueEntryExcel
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double TotalMass { get; set; }
        public int TotalQuantity { get; set; }
        public string Note { get; set; }

    }
}
