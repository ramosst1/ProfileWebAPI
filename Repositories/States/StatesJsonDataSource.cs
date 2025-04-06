using Models.States;
using Utilities.Converters.JsonObjectConverter;

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

                    var states = ConvertJsonToObject<List<StateDto>>(json);

                    statesList = states.Cast<StateDto>().ToList();
                }
            });

            return statesList;
        }

        private static TObject ConvertJsonToObject<TObject>(string json)
        {
            var response = JsonConverter.Convert<TObject>(json);

            return response;
        }

    }
}
