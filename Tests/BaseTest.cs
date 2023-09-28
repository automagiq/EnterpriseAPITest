using EnterpriseAPITest.Utilities;

public class BaseTest
{
    protected ApiClient _client;

    protected void Setup(string environmentUrl)
    {
        _client = new ApiClient(environmentUrl);
    }
}
