using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model.Api
{
    public class GoodsReceiptPost
    {
        public DateTime Timestamp { get; set; }
        public IEnumerable<GoodsReceiptEntryBasket> Entries {get;set;}
    }
    public class GoodsReceiptEntryBasket
    {
        public string BasketId { get; set; }
        public int ActualQuantity { get; set; }
    }
}
