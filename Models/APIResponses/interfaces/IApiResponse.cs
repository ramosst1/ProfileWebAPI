namespace Models.APIResponses.interfaces
{
    public interface IApiResponse
    {
        List<IErrorMessageModel> Messages { get; set; }
        bool Success { get; set; }
    }

    public interface IApiResponse<TResponse>: IApiResponse
    {
        TResponse? data { get; set; }
    }

}