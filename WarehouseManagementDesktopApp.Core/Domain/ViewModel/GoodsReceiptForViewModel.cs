using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.ViewModel
{
#pragma warning disable CS8618
    public class GoodsReceiptForViewModel 
    {
        [DisplayName("Mã rổ")]
        public string containerId { get; set; }

        [DisplayName("Mã SP")]
        public string itemId { get; set; }

        [DisplayName("Tên SP")]
        public string name { get; set; }

        [DisplayName("Ngày SX")]
        public string ProductionDate { get; set; }


        [DisplayName("Số Lượng")]
        public string? plannedQuantity { get; set; }

        [DisplayName("Khối lượng")]
        public string? actualQuantity { get; set; }

        [DisplayName("Đơn vị")]
        public string Unit { get; set; }
#pragma warning restore 
    }
}
