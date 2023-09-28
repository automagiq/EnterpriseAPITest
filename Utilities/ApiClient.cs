using System;
using System.Net.Http;

namespace EnterpriseAPITest.Utilities
{
    public class ApiClient
    {
        public HttpClient Client { get; private set; }

        public ApiClient(string baseUrl)
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }
    }
}