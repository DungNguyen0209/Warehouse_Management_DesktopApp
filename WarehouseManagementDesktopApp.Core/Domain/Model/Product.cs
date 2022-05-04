using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model
{
    public class Product
    {
#pragma warning disable CS8618
        public string Id { get; set; }
        public string Name { get; set; }
        public double PiecesPerKilogram { get; set; }
        public EUnit UnitOfMeasurement { get; set; }
    }
}
