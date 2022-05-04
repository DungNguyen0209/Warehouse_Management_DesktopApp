using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model.Api
{
    public class NewBasket
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public int plannedQuantity { get; set; }
        public DateTime ProductionDate { get; set; }

        public NewBasket(string id, string productId, int plannedQuantity, DateTime productionDate)
        {
            Id = id;
            ProductId = productId;
            this.plannedQuantity = plannedQuantity;
            ProductionDate = productionDate;
        }

        public NewBasket()
        {
        }
    }
}
