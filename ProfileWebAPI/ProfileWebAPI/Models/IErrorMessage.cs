namespace ProfileWebAPI.Models
{
    public interface IErrorMessage
    {
        string Message { get; set; }
        string FieldName { get; set; }
        string StatusCode { get; set; }
    }
}