using Profiles.Models.APIResponses;
using Models.Profiles;

namespace Models.APIResponses.Profiles
{
    public class ProfileResponse : ApiResponse
    {
        public ProfileModel Profile { get; set; }
    }
}
