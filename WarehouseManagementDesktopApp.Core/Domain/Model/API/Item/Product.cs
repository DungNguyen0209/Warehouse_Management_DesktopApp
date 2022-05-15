﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementDesktopApp.Core.Domain.Model
{
    public class Product
    {
#pragma warning disable CS8618
        public string itemId { get; set; }
        public string name { get; set; }
        public double piecesPerKilogram { get; set; }
        public double minimumStockLevel { get; set; }
        public double maximumStockLevel { get; set; }
        public EUnit unit { get; set; }
        public EItemSource itemSource { get; set; }
        public Manager? manager { get; set; }
    }
}
