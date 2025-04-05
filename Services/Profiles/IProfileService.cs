using Models.APIResponses.interfaces;
using Models.Profiles;
using Models.Profiles.interfaces;

namespace Profiles
{
    public interface IProfileService
    {

        Task<IApiResponse<global::Models.Profiles.interfaces.IProfileModel>> CreateProfileAsync(IProfileCreateModel aProfile);

        Task <IApiResponse> DeleteProfilesAsync(int profileIds);

        Task<IApiResponse<global::Models.Profiles.interfaces.IProfileModel>> GetProfileByIdAsync(int profileId);

        Task<IApiResponse<List<global::Models.Profiles.interfaces.IProfileModel>>> GetProfilesAsync();

        Task<IApiResponse<global::Models.Profiles.interfaces.IProfileModel>> UpdateProfileAsync(IProfileUpdateModel aProfile);

    }
}