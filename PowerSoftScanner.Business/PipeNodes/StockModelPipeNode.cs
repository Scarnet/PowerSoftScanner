using Infrastructure.Interfaces;
using Infrastructure.Pipeline;
using Infrastructure.Requests;
using PowerSoftScanner.Business.Models.ApiResponse;
using PowerSoftScanner.Business.Models.Business;
using PowerSoftScanner.Business.Models.Dtos;
using PowerSoftScanner.Configurations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PowerSoftScanner.Business.PipeNodes
{
    internal class StockModelPipeNode : IPipelineNode
    {
        private INetworkProvider networkProvider;
        public string Code { get; set; }
        public StockModelPipeNode(INetworkProvider networkProvider, string code)
        {
            Code = code;
            this.networkProvider = networkProvider;
        }
        public async Task<IPipePayLoad> Process(IPipePayLoad payload)
        {
            Dictionary<string, string> Parameters = new Dictionary<string, string>
            {
                { "token", ApiSettings.AuthToken},
                { "item_code_365", Code }
            };

            var httpRequest = new HttpRequest
            {
                Parameters = Parameters,
                Url = ApiSettings.BaseUrl + "list_stock_stores_item_model/"
            };
            var response = await this.networkProvider.Get<StockModelResponse, List<StockItemDto>>(httpRequest);
            return response;

        }
    }
}
