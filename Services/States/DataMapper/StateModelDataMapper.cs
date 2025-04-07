using Models.States;
using Repositories.Models.States;

namespace Services.States.DataMapper
{
    public static class StateModelDataMapper
    {
        public static List<StateModel> MapDataAsStateModel(this List<StateDto> list)
        {
            var results = new List<StateModel>();
            results.AddRange(
                list.Select(item => MapDataAsStateModel(item))
            );

            return results;
        }

        private static StateModel MapDataAsStateModel(this StateDto address)
        {
            return new StateModel()
            {
                StateAbreviation = address.StateAbrev,
                StateName = address.StateName
            };
        }
    }
}
