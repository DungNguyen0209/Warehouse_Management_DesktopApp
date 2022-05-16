using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model.Api
{

    public class GoodsIssueById
    {
        public string goodsIssueId { get; set; }
        public DateTime timestamp { get; set; }
        public bool confirmed { get; set; }
        public IEnumerable<GoodsIssueEntryById> entries { get; set; }
    }

    public class GoodsIssueEntryById
    {
        public Manager employee { get; set; }
        public Product item { get; set; }
        public double TotalQuantity { get; set; }
        public List<ContainerOfIssue> containers { get; set; }
        public string note { get; set; }
    }
    public class ContainerOfIssue
    {
        public string? containerId { get; set; }
        public double? quantity { get; set; }
        public string? productionDate { get; set; }
        public bool? isTaken { get; set; }

    }

    public class GoodsIssueEntryBasketById
    {
        public string Id { get; set; }
        public string StorageSlotId { get; set; }
        public int Quantity { get; set; }
        public double Mass { get; set; }
        public DateTime ProductionDate { get; set; }
        public bool IsTaken { get; set; }
    }

    public class HistoryGoodsIssue
    {
        public string Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public Manager ShiftLeader { get; set; }
        public IEnumerable<GoodsIssueEntryById> Entries { get; set; } = new List<GoodsIssueEntryById>();
    }

    public class PatchGoodsIssueEntryBasket
    {
        public string BasketId { get; set; }
        public int Quantity { get; set; }
    }
}