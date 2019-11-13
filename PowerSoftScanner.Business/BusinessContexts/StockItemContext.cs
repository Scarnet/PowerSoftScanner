using AutoMapper;
using Infrastructure.Interfaces;
using Infrastructure.Pipeline;
using Infrastructure.Requests;
using PowerSoftScanner.Business.Exceptions;
using PowerSoftScanner.Business.Interfaces;
using PowerSoftScanner.Business.Models.ApiResponse;
using PowerSoftScanner.Business.Models.Business;
using PowerSoftScanner.Business.Models.Dtos;
using PowerSoftScanner.Business.PipeNodes;
using PowerSoftScanner.Business.Validators;
using PowerSoftScanner.Configurations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PowerSoftScanner.Business.BusinessContexts
{
    public class StockItemContext : BusinessContext, IStockItemContext
    {
        private Pipeline pipeline;
        public StockItemContext(INetworkProvider networkProvider, IMapper mapper, Pipeline pipeline) : base(networkProvider, mapper)
        {
            this.pipeline = pipeline;
        }

        public async Task<List<StockItem>> GetStockItem(string code)
        {
            bool valid = NullObjectValidator.Validate(code);

            if (!valid)
                throw new ArgumentException("Invalid code has been passed to the context");

            var nodes = new IPipelineNode[] { new StockItemPipeNode(NetworkProvider, code), new StockModelPipeNode(NetworkProvider, code) };
            pipeline.SetNodes(nodes);
            var payload = (StockItemResponse)await pipeline.StartAsync();
            
            
            if (payload.ApiResponse.Code != "1")
                throw new BusinessException(payload.ApiResponse.Message ?? "Failed to get item from the server");

            var stockItems = Mapper.Map<List<StockItemDto>, List<StockItem>>(payload.Value);
            return stockItems;
        }


    }
}
