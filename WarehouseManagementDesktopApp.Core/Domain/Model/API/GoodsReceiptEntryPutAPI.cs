using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model.Api
{
    public class GoodsReceiptEntryPutAPI
    {
        public string ProductId { get; set; }
        public DateTime ProductionDate { get; set; }
        public int PlannedQuantity { get; set; }
        public int ActualQuantity { get; set; }

        public GoodsReceiptEntryPutAPI()
        {
        }

        public GoodsReceiptEntryPutAPI(string productId, DateTime productionDate, int plannedQuantity, int actualQuantity)
        {
            ProductId = productId;
            ProductionDate = productionDate;
            PlannedQuantity = plannedQuantity;
            ActualQuantity = actualQuantity;
        }
    }
}
