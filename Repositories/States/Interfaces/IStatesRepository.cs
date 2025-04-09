using Repositories.Models.States;

namespace Repositories.States.Interfaces
{
    public interface IStatesRepository
    {
        Task<List<StateDto>> GetAllStatesAsync();

    }
}