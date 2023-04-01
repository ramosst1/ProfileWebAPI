
using Models.Profiles;
using Models.States;
using Profiles.Models.APIResponses;

namespace Models.APIResponses.States
{
    public  class StatesResponse: ApiResponse
    {
        public List<StateModel> States { get; set; } = new List<StateModel>();

    }
}
