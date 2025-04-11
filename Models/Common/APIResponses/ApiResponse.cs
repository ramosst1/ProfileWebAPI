namespace Models.Common.APIResponses
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public List<ErrorMessageModel> ErrorMessages { get; set; } = new List<ErrorMessageModel>();
    }

    public class ApiResponse<TResponse>
    {
        public bool Success { get; set; }
        public List<ErrorMessageModel> ErrorMessages { get; set; } = new List<ErrorMessageModel>();

        public TResponse? data { get; set; }
    }

}
