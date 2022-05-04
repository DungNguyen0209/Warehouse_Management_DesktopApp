using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.ViewModel
{
    public class HistoryGoodsIssueViewModel
    {
        [DisplayName("Ngày xuất")]
        public string TimeStamp { get; set; }

        [DisplayName("Mã SP")]
        public string ProductId { get; set; }

        [DisplayName("Tên SP")]
        public string ProductName { get; set; }

        [DisplayName("Số lượng xuất")]
        public double ActualQuantity { get; set; }

        [DisplayName("KL xuất (Kg)")]
        public double ActualMass { get; set; }

        [DisplayName("Ngày SX")]
        public string ProductionDate { get; set; }
    }
}
