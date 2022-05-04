using WarehouseManagementDesktopApp.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Communication
{
    public class QueryStockCard<T>
    {
        public IEnumerable<T> Entries { get; set; } = new List<T>();
        public Product Product { get; set; }
    }
}
