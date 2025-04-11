using Models.Common.APIResponses;
using Models.States;

namespace Services.States.Interfaces
{
    public interface IStatesServices
    {
        Task<ApiResponse<List<StateModel>>> GetAllStatesAsync();
    }
}