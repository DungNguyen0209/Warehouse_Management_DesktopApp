using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model.Resource
{
    public class GoodsIssueEntry
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double TotalMass { get; set; }
        public int TotalQuantity { get; set; }
        public bool IsFinished { get; set; }
        public string GoodsIssueId { get; set; }

        public GoodsIssueEntry(int id, string productId, string productName, double totalMass, int totalQuantity, bool isFinished, string goodsIssueId)
        {
            Id = id;
            ProductId = productId;
            ProductName = productName;
            TotalMass = totalMass;
            TotalQuantity = totalQuantity;
            IsFinished = isFinished;
            GoodsIssueId = goodsIssueId;
        }

        public GoodsIssueEntry()
        {
        }

        public void CloneGoodsIssueEntry(GoodsIssueEntry entry)
        {
            this.Id = entry.Id;
            this.ProductId = entry.ProductId;
            this.ProductName = entry.ProductName;
            this.TotalQuantity = entry.TotalQuantity;
            this.TotalMass = entry.TotalMass;
            this.IsFinished = entry.IsFinished;
            this.GoodsIssueId = entry.GoodsIssueId;
        }
    }
}
