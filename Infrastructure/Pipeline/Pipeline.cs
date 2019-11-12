using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Pipeline
{
    public class Pipeline
    {
        private Stack<IPipelineNode> nodes;
        public Pipeline()
        {
        }
        public Pipeline SetNodes(params IPipelineNode[] nodes)
        {
            this.nodes = new Stack<IPipelineNode>(nodes);
            return this;
        }
        public async Task<IPipePayLoad> StartAsync()
        {
            if (this.nodes.Count <= 0)
                throw new ArgumentException("Can not process an empty pipe line, use SetNodes methods to init the pipline");

            return await NextAsync(null);
        }

        private async Task<IPipePayLoad> NextAsync(IPipePayLoad payload)
        {
            if (nodes.Count <= 0)
                return payload;

            var node = this.nodes.Pop();
            var output = await node.Process(payload);
            return await NextAsync(output);
        }
    }
}
