using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Requests
{
    public class HttpRequest
    {
        public string Url { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public Dictionary<string, string> Headers { get; set; }
    }
}
