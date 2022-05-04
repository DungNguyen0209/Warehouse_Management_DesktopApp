using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model.Resource
{
    public class GoodsIssueEntryBasket
    {
        public string StorageSlot { get; set; }
        public DateTime ProductionDate { get; set; }
        public double PlannedQuantity { get; set; }
        public double ActualQuantity { get; set; }
        public double QuantityToMass { get; set; }
        public bool IsOccupied { get; set; }
        public string CurrentProductId { get; set; }

        public GoodsIssueEntryBasket()
        {

        }

        public GoodsIssueEntryBasket(string storageSlot, DateTime productionDate, double plannedQuantity, double actualQuantity, double quantityToMass, bool isOccupied, string currentProductId)
        {
            StorageSlot = storageSlot;
            ProductionDate = productionDate;
            PlannedQuantity = plannedQuantity;
            ActualQuantity = actualQuantity;
            QuantityToMass = quantityToMass;
            IsOccupied = isOccupied;
            CurrentProductId = currentProductId;
        }

        public void Clone_GoodIssueEntryBasket(GoodsIssueEntryBasket entry)
        {
            this.StorageSlot = entry.StorageSlot;
            this.ProductionDate = entry.ProductionDate;
            this.PlannedQuantity = entry.PlannedQuantity;
            this.ActualQuantity = entry.ActualQuantity;
            this.QuantityToMass = entry.QuantityToMass;
            this.IsOccupied = entry.IsOccupied;
            this.CurrentProductId = entry.CurrentProductId;
        }
    }  
}
