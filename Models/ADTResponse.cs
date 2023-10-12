namespace EnterpriseAPITest.Models
{
    public class ADTResponse
    {
        public string Message { get; set; }
        public ADT Data { get; set; }
    }

    public class ADT
    {
        public string Name { get; set; }
    }
}
