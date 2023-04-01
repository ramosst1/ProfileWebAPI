using Models.States;
using Newtonsoft.Json;

namespace Repositories.States
{
    public class StatesJsonDataSource : IStatesDataSource
    {
        const string JSON_STATES_DATASOURCE = "../Repositories/JsonData/States.json";

        async Task<List<StateDto>> IStatesDataSource.GetAllStates()
        {
            var statesList = new List<StateDto>();

            await Task.Run(() =>
            {
                using (StreamReader r = new StreamReader(JSON_STATES_DATASOURCE))
                {
                    string json = r.ReadToEnd();

                    var states = JsonConvert.DeserializeObject<List<StateDto>>(json);

                    statesList = states.Cast<StateDto>().ToList();
                }
            });

            return statesList;
        }

    }
}
