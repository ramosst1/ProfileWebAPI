using Models.APIResponses.States;

namespace Services.States
{
    public interface IStatesServices
    {
        Task<StatesResponse> GetAllStatesAsync();
    }
}