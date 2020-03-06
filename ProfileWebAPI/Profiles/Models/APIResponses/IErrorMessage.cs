namespace Profiles.Models.APIResponses
{
    public interface IErrorMessage
    {
        string ExternalMessage { get; set; }
        string InternalMessage { get; set; }
        string StatusCode { get; set; }
    }
}