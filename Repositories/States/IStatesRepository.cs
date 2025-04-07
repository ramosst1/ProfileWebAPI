using Repositories.Models.States;

namespace Repositories.States
{
    public interface IStatesRepository
    {
        Task<List<StateDto>> GetAllStatesAsync();

    }
}