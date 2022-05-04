using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model
{
    public class Basket
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime ProductionDate { get; set; }
        public int PlannedQuantity { get; set; }
        public int? ActualQuantity { get; set; }
        public double PlannedMass { get; set; }
        public double? ActualMass { get; set; }
        public EUnit Unit { get; set; }

        public Basket()
        {

        }

        public Basket(string basketId, string productId, string productName, DateTime productionDate, int plannedQuantity, int actualQUantity, EUnit unit)
        {
            Id = basketId;
            ProductId = productId;
            ProductName = productName;
            ProductionDate = productionDate;
            PlannedQuantity = plannedQuantity;
            ActualQuantity = actualQUantity;
            Unit = unit;
        }

        
    }
}
