using Models.States;
using Profiles.Models.APIResponses;

namespace Services.States.Interfaces
{
    public interface IStatesServices
    {
        Task<ApiResponse<List<StateModel>>> GetAllStatesAsync();
    }
}