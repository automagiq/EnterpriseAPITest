using System.Net.Http;
using System.Text;
using EnterpriseAPITest.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace EnterpriseAPITest.Tests
{
    public partial class SampleTests : BaseTest
    {
        public SampleTests()
        {
            Setup("http://postman-api-learner.glitch.me");
        }

        [Test]
        [TestCase("info")]
        //[TestCase("anotherEndpoint")] // replace with another endpoint if you have one
        public async Task PostAndValidateResponse(string endpoint)
        {
            // Construct the full URL
            var TestUrl = $"{_client.Client.BaseAddress}/{endpoint}";

            // If you need to send a POST request, then set up your POST data
            var requestBody = new
            {
                name = "John Doe"
            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            // Send the POST request
            var response = await _client.Client.PostAsync(TestUrl, jsonContent);

            // Ensure the request was successful
            response.EnsureSuccessStatusCode();

            // Deserialize the response content
            var content = await response.Content.ReadAsStringAsync();
            var ADPResponse = JsonConvert.DeserializeObject<ADPResponse>(content);

            // Validate the response
            Assert.AreEqual("You made a POST request with the following data!", ADPResponse.Message);
            Assert.AreEqual("John Doe", ADPResponse.Data.Name);

        }
    }
}
