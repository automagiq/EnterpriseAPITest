namespace EnterpriseAPITest.Models
{
    public class SampleResponse
    {
        public string Message { get; set; }
        public Sample Data { get; set; }
    }

    public class Sample
    {
        public string Name { get; set; }
    }
}
