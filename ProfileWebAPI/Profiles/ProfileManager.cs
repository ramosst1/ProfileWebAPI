using Profiles.Models.APIResponses;
using Profiles.Models.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profiles
{
    public class ProfileManager : IProfileManager
    {

        IProfileManager _ProjectManagerData;

        public ProfileManager()
        {
            _ProjectManagerData = new Profiles.Models.ProfileJson.ProfileJsonManager();
        }

        public IProfileResponse CreateProfile(string firstName, string lastName, bool active) {

            return _ProjectManagerData.CreateProfile(firstName, lastName, active);

        }

        public IProfileResponse GetProfileById(int profileId) {
            return _ProjectManagerData.GetProfileById(profileId);
        }

        public IProfileResponse UpdateProfile(IProfile aProfile)
        {

            return _ProjectManagerData.UpdateProfile(aProfile);
        }

        public IProfileResponse DeleteProfiles(int profileIds)
        {
            return _ProjectManagerData.DeleteProfiles(profileIds);

        }

        public IProfilesResponse GetProfiles()
        {
            return _ProjectManagerData.GetProfiles();
        }

    }

}
