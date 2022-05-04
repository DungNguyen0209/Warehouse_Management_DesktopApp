using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model
{
    public class BasketInStorageSlot
    {
        public string Id { get; set; }
        public Product Product { get; set; }
        public int PlannedQuantity { get; set; }
        public int? ActualQuantity { get; set; }
        public double PlannedMass { get; set; }
        public double? ActualMass { get; set; }
        public DateTime ProductionDate { get; set; }
    } 

    public class StorageSlot
    {
        public string Id { get; set; }
        public Boolean IsOccupied { get; set; }
        public BasketInStorageSlot Basket { get; set; }
    }
    
}
