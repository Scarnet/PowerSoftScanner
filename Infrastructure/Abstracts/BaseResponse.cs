using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Abstracts
{
    /// <summary>
    /// Contains the state properties for each API response
    /// </summary>
    public class ApiResponse
    {
        [JsonProperty("response_code")]
        public string Code { get; set; }
        [JsonProperty("response_msg")]
        public string Message { get; set; }
        [JsonProperty("response_id")]
        public string Id { get; set; }
    }

    /// <summary>
    /// Base response class for all API calls
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseResponse<T> 
    {
        [JsonProperty("api_response")]
        public ApiResponse ApiResponse { get; set; }
        public abstract T Value { get; set; }
    }
}
