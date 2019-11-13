using PowerSoftScanner.Business.Models.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerSoftScanner.Models
{
    public class Store
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<StockItem> Items { get; set; }
    }
}
