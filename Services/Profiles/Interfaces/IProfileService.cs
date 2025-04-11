using Models.Common.APIResponses;
using Models.Profiles;

namespace Services.Profiles.Interfaces
{
    public interface IProfileService
    {

        Task<ApiResponse<ProfileModel>> CreateProfileAsync(ProfileCreateModel aProfile);

        Task <ApiResponse> DeleteProfilesAsync(int profileIds);

        Task<ApiResponse<ProfileModel>> GetProfileByIdAsync(int profileId);

        Task<ApiResponse<List<ProfileModel>>> GetProfilesAsync();

        Task<ApiResponse<ProfileModel>> UpdateProfileAsync(ProfileUpdateModel aProfile);

    }
}