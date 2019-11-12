using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Pipeline
{
    public interface IPipelineNode
    {
        Task<IPipePayLoad> Process(IPipePayLoad payload);
    }
}
