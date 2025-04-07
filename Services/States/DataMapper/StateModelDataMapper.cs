using Models.States;
using Repositories.Models.States;

namespace Services.States.DataMapper
{
    public static class StateModelDataMapper
    {
        public static List<StateModel> MapData(this List<StateDto> list)
        {
            var results = new List<StateModel>();
            results.AddRange(
                list.Select(item => MapData(item))
            );

            return results;
        }

        private static StateModel MapData(this StateDto address)
        {
            return new StateModel()
            {
                StateAbrev = address.StateAbrev,
                StateName = address.StateFullName
            };
        }
    }
}
