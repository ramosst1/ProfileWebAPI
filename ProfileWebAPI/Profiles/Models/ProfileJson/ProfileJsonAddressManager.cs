using System;
using System.Collections.Generic;
using System.Text;
using Profiles.Models.APIResponses;
using Profiles.Models.Profiles;
using System.Linq;

namespace Profiles.Models.ProfileJson
{
    class ProfileJsonAddressManager : IProfileJsonAddressManager
    {
        private readonly IProfileJsonManager _ProfileJsonManager;
        private readonly IProfileJson _ProfileJson;
        private readonly IAddressDataPopulate _AddressPopulateMgr;
        private readonly IProfile _Profile; 
        public ProfileJsonAddressManager(IProfileJson aProfile)
        {
            _ProfileJsonManager = new ProfileJsonManager();
            _ProfileJson = aProfile;

            var ProfileManger2 = (IProfileManager)_ProfileJsonManager;

            _Profile = ProfileManger2.GetProfileById(aProfile.ProfileId).Profile;

            _AddressPopulateMgr = new AddressPopulate(ProfileManger2, _Profile);

        }
        public IProfileAddress Create(
            string address1, string address2, string city, string stateAbev, 
            string zipCode, bool isPrimary, bool isSecondary 
        )
        {

            var NewAddress = _AddressPopulateMgr.PopulateUpSertAddress(0, address1, address2, city, stateAbev, zipCode, isPrimary, isSecondary);

            _Profile.Addresses.Add(NewAddress);

            _ProfileJsonManager.UpdateProfile(_Profile);

            return NewAddress;
        }
    }
}
