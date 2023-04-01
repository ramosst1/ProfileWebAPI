using Models.States;
namespace Repositories.States
{
    public interface IStatesDataSource
    {
        internal protected Task<List<StateDto>> GetAllStates();
    }
}