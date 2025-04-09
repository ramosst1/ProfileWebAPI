using Repositories.Models.States;
namespace Repositories.States.Interfaces
{
    public interface IStatesDataSource
    {
        internal protected Task<List<StateDto>> GetAllStates();
    }
}