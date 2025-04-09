using Repositories.Models.Profiles;

namespace Repositories.Profiles.Interfaces
{
    public interface IProfileDataSource
    {
        internal protected Task<List<ProfileDto>> GetProfilesAsync();

        internal protected Task WriteJsonToFileAsync(string jsonContent);
    }
}