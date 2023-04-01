using Profiles.Models.APIResponses;
using Models.Profiles;

namespace Models.APIResponses.Profiles
{
    public class ProfilesResponse : ApiResponse
    {
        public List<ProfileModel> Profiles { get; set; }
    }
}
