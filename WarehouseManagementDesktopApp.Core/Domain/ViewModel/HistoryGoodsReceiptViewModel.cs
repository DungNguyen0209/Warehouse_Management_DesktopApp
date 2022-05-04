using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.ViewModel
{
    public class HistoryGoodsReceiptViewModel
    {
        [DisplayName("Ngày nhập")]
        public string TimeStamp { get; set; }

        [DisplayName("Mã SP")]
        public string ProductId { get; set; }

        [DisplayName("Tên SP")]
        public string ProductName { get; set; }

        [DisplayName("KL SX")]
        public double PlannedMass { get; set; }

        [DisplayName("KL kho")]
        public double ActualMass { get; set; }

        [DisplayName("SL SX")]
        public double PlannedQuantity { get; set; }

        [DisplayName("SL kho")]
        public double ActualQuantity { get; set; }

        [DisplayName("Ngày sản xuất")]
        public string ProductionDate { get; set; }
    }
}
