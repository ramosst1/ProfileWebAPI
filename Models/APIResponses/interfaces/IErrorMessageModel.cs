namespace Models.APIResponses.interfaces
{
    public interface IErrorMessageModel
    {
        string ExternalMessage { get; set; }
        string InternalMessage { get; set; }
        string StatusCode { get; set; }
    }
}