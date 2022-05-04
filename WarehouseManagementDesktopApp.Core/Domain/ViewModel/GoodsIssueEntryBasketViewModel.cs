using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.ViewModel
{
    public class GoodsIssueEntryBasketViewModel
    {
        [DisplayName("Vị trí rổ")]
        public string StorageSlot { get; set; }

        [DisplayName("Ngày")]
        public string ProductionDate { get; set; }

        [DisplayName("Hiện có")]
        public int TotalQuantity { get; set; }

        [DisplayName("Đã lấy")]
        public int ActualQuantity { get; set; }

        [DisplayName("Quy đổi")]
        public double Mass { get; set; }

        [DisplayName("Chọn rổ")]
        public bool IsSelected { get; set; }
    }
}
