using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.ViewModel
{
    public class HistoryBasketUnconsistenciesViewModel
    {
        [DisplayName("Đã sửa")]
        public bool IsFixed { get; set; }

        [DisplayName("Ngày xuất")]
        public string TimeStamp { get; set; }

        [DisplayName("Mã rổ")]
        public string BasketId { get; set; }

        [DisplayName("Mã SP")]
        public string ProductId { get; set; }

        [DisplayName("SL sai")]
        public double CurrentQuantity { get; set; }

        [DisplayName("SL đã sửa")]
        public double NewQuantity { get; set; }

        [DisplayName("KL sai")]
        public double CurrentMass { get; set; }

        [DisplayName("KL đã sửa")]
        public double NewMass { get; set; }

        [DisplayName("Người sửa")]
        public string EmployeeName { get; set; }

        [DisplayName("Ghi chú")]
        public string Note { get; set; }
    }
}
