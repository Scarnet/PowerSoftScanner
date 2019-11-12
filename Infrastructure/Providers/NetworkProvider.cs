using Infrastructure.Abstracts;
using Infrastructure.Interfaces;
using Infrastructure.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Infrastructure.Providers
{
    public class NetworkProvider : INetworkProvider
    {
        private int httpclientPoolSize = 10;
        private SemaphoreSlim semaphore;

        public NetworkProvider()
        {
            this.semaphore = new SemaphoreSlim(httpclientPoolSize);
        }
        public async Task<T> Get<T, L>(HttpRequest request) where T : BaseResponse<L>
        {
            var client = await GetHttpClient(request.Headers);
            var builder = new UriBuilder(request.Url);
            var query = HttpUtility.ParseQueryString(string.Empty);

            foreach (var param in request.Parameters)
                query[param.Key] = param.Value;

            builder.Query = query.ToString();

            var response = await client.GetAsync(builder.ToString());

            return await ParseHttpResponse<T, L>(response);
        }
        public Task<T> Post<T, L>(HttpRequest request) where T : BaseResponse<L>
        {
            throw new NotImplementedException();
        }

        public Task<T> Put<T, L>(HttpRequest request) where T : BaseResponse<L>
        {
            throw new NotImplementedException();
        }

        private async Task<T> ParseHttpResponse<T, L>(HttpResponseMessage response) where T : BaseResponse<L>
        {
            string responseStr = await response.Content.ReadAsStringAsync();
            var baseResponse = JsonConvert.DeserializeObject<T>(responseStr);
            return baseResponse;
        }
        private async Task<HttpClient> GetHttpClient(Dictionary<string, string> headers)
        {
            await this.semaphore.WaitAsync();

            var client = new HttpClient();

            if (headers != null)
                foreach (var header in headers)
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);

            return client;
        }

    }
}
