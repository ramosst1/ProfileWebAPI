using Repositories.Models.Profiles;

namespace Repositories.Profiles.Interfaces
{
    public interface IProfileRepository
    {
        Task<ProfileDto> GetProfileByIdAsync(int profileId);

        Task<List<ProfileDto>> GetProfilesAsync();

        Task<ProfileDto> CreateProfileAsync(ProfileCreateDto aProfile);

        Task<ProfileDto> UpdateProfileAsync(ProfileUpdateDto aProfile);

        Task<bool> DeleteProfileAsync(int profileIds);

    }
}
