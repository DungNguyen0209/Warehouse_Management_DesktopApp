using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.ViewModel
{
    public class StockCardViewModel
    {
        [DisplayName("Ngày xuất/nhập")]
        public string Date { get; set; }

        [DisplayName("Tồn đầu")]
        public double Before { get; set; }

        [DisplayName("SL/KL nhập")]
        public double Input { get; set; }

        [DisplayName("SL/KL xuất")]
        public double Output { get; set; }

        [DisplayName("Tồn cuối")]
        public double After { get; set; }

        [DisplayName("Ghi chú")]
        public string Note { get; set; }
    }
}
