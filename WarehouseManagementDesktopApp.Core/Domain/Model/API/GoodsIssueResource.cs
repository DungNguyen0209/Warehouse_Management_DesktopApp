using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model.Api
{
    public class GoodsIssueResource
    {
        public string Id { get; set; }
        public DateTime Timestamp { get; set; }
        public IEnumerable<GoodsIssueEntryResource> Entries { get; set; }

    }
    public class GoodsIssueEntryResource
    {
        public string ProductId { get; set; }
        public int TotalQuantity { get; set; }

        public GoodsIssueEntryResource()
        {
        }
    }

    public class GoodsIssueEntryBasketResource
    {
        public string BasketId { get; set; }
        public int Quantity { get; set; }

        public GoodsIssueEntryBasketResource()
        {
        }

        public GoodsIssueEntryBasketResource(string basketId, int actualQuantity)
        {
            BasketId = basketId;
            Quantity = actualQuantity;
        }
    }


}
