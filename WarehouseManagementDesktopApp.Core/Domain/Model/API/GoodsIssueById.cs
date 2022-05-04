using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model.Api
{

    public class GoodsIssueById
    {
        public string Id { get; set; }
        public DateTime Timestamp { get; set; }
        public IEnumerable<GoodsIssueEntryById> Entries { get; set; }
    }

    public class GoodsIssueEntryById
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public EUnit ProductUnitOfMeasurement { get; set; }
        public int TotalQuantity { get; set; }
        public double TotalMass { get; set; }
        public WarehouseEmployee Employee { get; set; }
        public IEnumerable<GoodsIssueEntryBasketById> Baskets { get; set; }
        public string Note { get; set; }
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
        public WarehouseEmployee ShiftLeader { get; set; }
        public IEnumerable<GoodsIssueEntryById> Entries { get; set; } = new List<GoodsIssueEntryById>();
    }

    public class PatchGoodsIssueEntryBasket
    {
        public string BasketId { get; set; }
        public int Quantity { get; set; }

        public PatchGoodsIssueEntryBasket()
        {
        }
    }
}