
namespace Models.APIResponses
{
    public class ErrorMessageModel
    {
        public string InternalMessage { get; set; }
        public string ExternalMessage { get; set; }
        public string StatusCode { get; set; }
    }
}
