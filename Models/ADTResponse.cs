namespace EnterpriseAPITest.Models
{
    public class ADTResponse
    {
        public string Message { get; set; }
        public ADP Data { get; set; }
    }

    public class ADP
    {
        public string Name { get; set; }
    }
}
