namespace Models.Common.APIResponses
{
    public class ErrorMessageModel
    {
        public string InternalMessage { get; set; } = string.Empty;
        public string ExternalMessage { get; set; } = string.Empty;
        public string StatusCode { get; set; } = string.Empty;
    }
}
