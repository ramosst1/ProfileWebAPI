using Models.APIResponses.Profiles;
using Models.Profiles;
using Profiles.Models.APIResponses;

namespace Profiles
{
    public interface IProfileService
    {

        Task <ProfileResponse> CreateProfileAsync(ProfileCreateModel aProfile);

        Task <ApiResponse> DeleteProfilesAsync(int profileIds);

       Task<ProfileResponse> GetProfileByIdAsync(int profileId);

        Task<ProfilesResponse> GetProfilesAsync();

        Task<ProfileResponse> UpdateProfileAsync(ProfileUpdateModel aProfile);


    }
}