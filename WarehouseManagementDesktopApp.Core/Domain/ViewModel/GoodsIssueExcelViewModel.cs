using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.ViewModel
{
    public class GoodsIssueExcelViewModel
    {

        [DisplayName("STT")]
        public int Id { get; set; }

        [DisplayName("Mã hàng")]
        public string ProductId { get; set; }

        [DisplayName("Tên hàng")]
        public string ProductName { get; set; }

        [DisplayName("Kg")]
        public double Mass { get; set; }

        [DisplayName("Bộ/Cái")]
        public int Quantity { get; set; }

        [DisplayName("Đã xong")]
        public bool IsFinish { get; set; }
    }
}
