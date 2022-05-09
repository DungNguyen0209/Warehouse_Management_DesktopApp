using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model.Api
{
    public class BasketInconsistency
    {
        public DateTime TimeStamp { get; set; }
        public string BasketId { get; set; }
        public string StorageSlotId { get; set; }
        public string ProductId { get; set; }
        public string GoodsIssueId { get; set; }
        public int CurrentQuantity { get; set; }
        public double CurrentMass { get; set; }
        public int NewQuantity { get; set; }
        public double NewMass { get; set; }
        public string Note { get; set; }
        public Boolean IsFixed { get; set; }
        public Manager Reporter { get; set; }

        public BasketInconsistency()
        {
        }
    }
}
