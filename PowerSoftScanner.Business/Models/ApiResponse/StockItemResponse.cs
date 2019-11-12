using Infrastructure.Abstracts;
using Infrastructure.Pipeline;
using Newtonsoft.Json;
using PowerSoftScanner.Business.Models.Business;
using PowerSoftScanner.Business.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerSoftScanner.Business.Models.ApiResponse
{
    public class StockItemResponse : BaseResponse<List<StockItemDto>>, IPipePayLoad
    {
        [JsonProperty("list_stock_stores_item")]
        public override List<StockItemDto> Value { get; set; }
    }
}
