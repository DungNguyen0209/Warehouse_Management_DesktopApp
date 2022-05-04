using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model.Resource
{
    public class GoodsReceiptEntryResource
    {
        public string BasketId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime ProductionDate { get; set; }
        public int PlannedQuantity { get; set; }
        public int ActualQuantity { get; set; }
        public double PlannedMass { get; set; }
        public double ActualMass { get; set; }
        public EUnit Unit { get; set; }


        public GoodsReceiptEntryResource()
        {
        }

        public GoodsReceiptEntryResource(string basketId, string productId, string productName, DateTime productionDate, int plannedQuantity, int actualQuantity, double plannedMass, double actualMass, EUnit unit)
        {
            BasketId = basketId;
            ProductId = productId;
            ProductName = productName;
            ProductionDate = productionDate;
            PlannedQuantity = plannedQuantity;
            ActualQuantity = actualQuantity;
            PlannedMass = plannedMass;
            ActualMass = actualMass;
            Unit = unit;
        }

        public void Clone(GoodsReceiptEntryResource entry)
        {
            this.BasketId = entry.BasketId;
            this.ProductId = entry.ProductId;
            this.ProductName = entry.ProductName;
            this.ProductionDate = entry.ProductionDate;
            this.PlannedQuantity = entry.PlannedQuantity;
            this.ActualQuantity = entry.ActualQuantity;
            this.PlannedMass = entry.PlannedMass;
            this.ActualMass = entry.ActualMass;
            this.Unit = entry.Unit;
        }
    }
}
