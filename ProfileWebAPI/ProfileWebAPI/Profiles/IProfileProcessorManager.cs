using ProfileWebAPI.Models.Profiles;

namespace ProfileWebAPI.ProfilesProcessors
{
    public interface IProfileProcessorManager
    {
        IProfileResponse CreateProfile(IProfileNew aProfile);
        IProfileResponse UpdateProfile(IProfile profile);
    }
}