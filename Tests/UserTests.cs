using Newtonsoft.Json;
using NUnit.Framework;

namespace EnterpriseAPITest.Tests
{
    public partial class UserTests : BaseTest
    {
        public UserTests()
        {
            Setup("http://httpbin.org");
        }

        [Test]
        [TestCase("uuid", "OK")]
        public async Task GetHttpBinEndPoints(string endPoint, string acceptanceCode)
        {
            var TestUrl = $"{_client.Client.BaseAddress}/{endPoint}";
            HttpResponseMessage apiResponse = await _client.Client.GetAsync(TestUrl);
            string responseCode = apiResponse.StatusCode.ToString();

            // Check the response status code first
            Assert.AreEqual(acceptanceCode, responseCode, 
                $"For {TestUrl} Expected Response Code: {acceptanceCode} but got {responseCode}");

            if (apiResponse.IsSuccessStatusCode)
            {
                // Deserialize the response content
                var content = await apiResponse.Content.ReadAsStringAsync();
                var userResponse = JsonConvert.DeserializeObject<UserResponse>(content);

                // Validate the UUID property
                Assert.IsNotNull(userResponse.Uuid, "Expected UUID not to be null in the response");
                Assert.IsNotEmpty(userResponse.Uuid, "Expected UUID not to be empty in the response");

            }
        }
    }
}
