using System.Collections.Generic;
using Profiles.Models.Profiles;
using Profiles.Models.APIResponses;
namespace Profiles
{
    public interface IProfileManager
    {

        IProfileResponse CreateProfile(string firstName, string lastName, bool active);

        IProfileResponse DeleteProfiles(int profileIds);

        IProfileResponse GetProfileById(int profileId);

        IProfilesResponse GetProfiles();

        IProfileResponse UpdateProfile(IProfile aProfile);
    }
}