using Repositories.Models.States;

namespace Repositories.States
{
    public class StatesRepository : IStatesRepository
    {
        const string JSON_STATES_DATASOURCE = "../Repositories/JsonData/States.json";
        private readonly IStatesDataSource _statesJsonDataSource;

        public StatesRepository(IStatesDataSource statesJsonDataSource)
        {
            _statesJsonDataSource = statesJsonDataSource;
        }

        public async Task<List<StateDto>> GetAllStatesAsync()
        {
            return await _statesJsonDataSource.GetAllStates();
        }
    }
}
