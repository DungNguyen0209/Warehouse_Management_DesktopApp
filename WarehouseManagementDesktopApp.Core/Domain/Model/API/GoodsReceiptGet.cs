using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model.Api
{
    public class GoodsReceiptGet
    {
        public DateTime Timestamp { get; set; }
        public WarehouseEmployee Employee { get; set; }
        public List<GetAllGoodsReceipt> Entries { get; set; }
    }
    public class GetAllGoodsReceipt
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string BasketId { get; set; }
        public int PlannedQuantity { get; set; }
        public int ActualQuantity { get; set; }
        public double PlannedMass { get; set; }
        public double ActualMass { get; set; }
        public DateTime ProductionDate { get; set; }
    }
}
