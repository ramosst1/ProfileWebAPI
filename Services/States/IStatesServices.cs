using Models.States;
using Profiles.Models.APIResponses;

namespace Services.States
{
    public interface IStatesServices
    {
        Task<ApiResponse<List<StateModel>>> GetAllStatesAsync();
    }
}