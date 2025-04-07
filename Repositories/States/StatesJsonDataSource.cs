using Repositories.Models.States;
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
                string statesJson = ReadFromStreamReader(JSON_STATES_DATASOURCE);

                var states = ConvertJsonToObject<List<StateDto>>(statesJson);

                statesList = states.Cast<StateDto>().ToList();
            });

            return statesList;
        }

        private static string ReadFromStreamReader(string filePathSource) {
            using (StreamReader r = new StreamReader(filePathSource))
            {
                 return r.ReadToEnd();
            }
        }

        private static TObject ConvertJsonToObject<TObject>(string json)
        {
            var response = JsonConverter.Convert<TObject>(json);

            return response;
        }

    }
}
