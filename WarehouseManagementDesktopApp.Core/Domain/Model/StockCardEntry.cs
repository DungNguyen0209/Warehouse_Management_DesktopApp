using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model
{
    public class StockCardEntry
    {
        public string ProductId { get; set; }
        public DateTime Date { get; set; }
        public int BeforeQuantity { get; set; }
        public int InputQuantity { get; set; }
        public int OutputQuantity { get; set; }
        public int AfterQuantity { get; set; }
        public double BeforeMass { get; set; }
        public double InputMass { get; set; }
        public double OutputMass { get; set; }
        public double AfterMass { get; set; }
        public string Note { get; set; }

        public StockCardEntry()
        {
        }

        public StockCardEntry(DateTime date, int beforeQuantity, int inputQuantity, int outputQuantity, int afterQuantity, string note)
        {
            Date = date;
            BeforeQuantity = beforeQuantity;
            InputQuantity = inputQuantity;
            OutputQuantity = outputQuantity;
            AfterQuantity = afterQuantity;
            Note = note;
        }
    }
}
