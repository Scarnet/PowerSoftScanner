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
        /// <summary>
        /// Perform GET operation
        /// </summary>
        /// <typeparam name="T">Response object</typeparam>
        /// <typeparam name="L">Business object</typeparam>
        Task<T> Get<T, L>(HttpRequest request) where T : BaseResponse<L>;
        /// <summary>
        /// Perform POST operation
        /// </summary>
        /// <typeparam name="T">Response object</typeparam>
        /// <typeparam name="L">Business object</typeparam>
        Task<T> Post<T, L>(HttpRequest request) where T : BaseResponse<L>;
        /// <summary>
        /// Perform PUT operation
        /// </summary>
        /// <typeparam name="T">Response object</typeparam>
        /// <typeparam name="L">Business object</typeparam>
        Task<T> Put<T, L>(HttpRequest request) where T : BaseResponse<L>;

    }
}
