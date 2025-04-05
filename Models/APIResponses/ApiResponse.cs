using Models.APIResponses.interfaces;

namespace Profiles.Models.APIResponses
{
    public abstract class ApiResponseBase {

        private protected ApiResponseBase(){}

        public bool Success { get; set; }

        public List<IErrorMessageModel> Messages { get; set; } = new List<IErrorMessageModel>();
    }

    public class ApiResponse : ApiResponseBase, IApiResponse
    {
    }

    public class ApiResponse<TResponse>: ApiResponseBase, IApiResponse<TResponse>
    {
        public TResponse? data { get; set; }
    }

}
