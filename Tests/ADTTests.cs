using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace EnterpriseAPITest.Tests
{
    public class ADTConfigurationTests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient();
        }

        [Test]
        public async Task ValidateADTIsConfigured()
        {
            // Setup data for token request
            var tokenUrl = "https://reidentityws.devint.dev-r5ead.net/connect/token";
            var requestData = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "client_id", "appsdataclient" },
                { "client_secret", "secret" }
            };

            // Request token
            var response = await _client.PostAsync(tokenUrl, new FormUrlEncodedContent(requestData));
            response.EnsureSuccessStatusCode();

            // Extract token from response
            string token = await response.Content.ReadAsStringAsync(); // directly read the string content

            // Setup request to check if ADT is configured
            var requestUrl = "https://reappdatamanagerws.devint.dev-r5ead.net/api/IsADTConfigured";
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            // Make the request
            response = await _client.GetAsync(requestUrl);

            // Check status code
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Expected a status code of 200 OK");

            // Check response content
            bool isADTConfigured = bool.Parse(await response.Content.ReadAsStringAsync());
            Assert.IsTrue(isADTConfigured, "Expected the response body to be true");
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
        }
    }
}
