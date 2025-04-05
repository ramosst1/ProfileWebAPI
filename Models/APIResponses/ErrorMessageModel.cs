
using Models.APIResponses.interfaces;

namespace Models.APIResponses
{
    public class ErrorMessageModel : IErrorMessageModel
    {
        public string InternalMessage { get; set; } = string.Empty;
        public string ExternalMessage { get; set; } = string.Empty;
        public string StatusCode { get; set; } = string.Empty;
    }
}
