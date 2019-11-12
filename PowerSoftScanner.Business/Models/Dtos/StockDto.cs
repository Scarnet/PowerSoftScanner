using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerSoftScanner.Business.Models.Dtos
{
    public class StockItemDto
    {
        [JsonProperty("store_code_365")]
        public string StoreCode { get; set; }
        [JsonProperty("store_name")]
        public string StoreName { get; set; }
        [JsonProperty("store_active")]
        public bool StoreActive { get; set; }
        [JsonProperty("item_code_365")]
        public string ItemCode { get; set; }
        [JsonProperty("model_code_365")]
        public string ModelCode { get; set; }
        [JsonProperty("item_name")]
        public string Name { get; set; }
        [JsonProperty("stock")]
        public decimal Stock { get; set; }
        [JsonProperty("stock_on_transfer")]
        public decimal StockInTransfer { get; set; }
        [JsonProperty("stock_reserved")]
        public decimal StockReserved { get; set; }
        [JsonProperty("stock_ordered")]
        public decimal StockOrdered { get; set; }
        [JsonProperty("mininum_stock")]
        public decimal MinimumStock { get; set; }
        [JsonProperty("required_stock")]
        public decimal RequiredStock { get; set; }
        [JsonProperty("model_name")]
        public string ModelName { get; set; }
        [JsonProperty("color_code_365")]
        public string ColorCode { get; set; }
        [JsonProperty("color_name")]
        public string ColorName { get; set; }
        [JsonProperty("color_html")]
        public string ColorHex { get; set; }
        [JsonProperty("size_code_365")]
        public string SizeCode { get; set; }
        [JsonProperty("size_name")]
        public string SizeName { get; set; }
        [JsonProperty("size_name_invoice")]
        public string SizeNameInvoice { get; set; }
        [JsonProperty("size_sequence")]
        public int SizeSequence { get; set; }


    }
}
