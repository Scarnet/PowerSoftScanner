using Infrastructure.Abstracts;
using Infrastructure.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface INetworkProvider
    {
        Task<BaseResponse<T>> Get<T>(HttpRequest request);
        Task<BaseResponse<T>> Post<T>(HttpRequest request);
        Task<BaseResponse<T>> Put<T>(HttpRequest request);

    }
}
