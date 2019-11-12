using Infrastructure.Pipeline;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerSoftScanner.Business.Models.Business
{
    public class StockItem
    {
        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public bool StoreActive { get; set; }
        public string ItemCode { get; set; }
        public string ModelCode { get; set; }
        public string Name { get; set; }
        public decimal Stock { get; set; }
        public decimal StockInTransfer { get; set; }
        public decimal StockReserved { get; set; }
        public decimal StockOrdered { get; set; }
        public decimal MinimumStock { get; set; }
        public decimal RequiredStock { get; set; }
        public string ModelName { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string ColorHex { get; set; }
        public string SizeCode { get; set; }
        public string SizeName { get; set; }
        public string SizeNameInvoice { get; set; }
        public int SizeSequence { get; set; }

    }
}
