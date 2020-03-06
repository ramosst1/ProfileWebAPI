using System;
using System.Collections.Generic;
using System.Text;
using Profiles.Models.APIResponses;
using Profiles.Models.ProfileJson;
using Profiles.Models.Profiles;

namespace Profiles.Models.Profiles
{
    public class ProfileAddressManager : IProfileAddressManager
    {
        private readonly IProfile _Profile;
        private readonly IProfileJson _ProfileJson;

        public ProfileAddressManager(IProfile aProfile)
        {
            _Profile = aProfile;

            var ProfileMngr = new ProfileJsonManager();

            _ProfileJson = ProfileMngr.GetJsonProfileByProfileId(_Profile.ProfileId);

        }

        public IAddressesResponse Create(string address1, string address2, string city, string stateAbev, string zipCode, AddressTypes addressType) {

            IAddressesResponse Response = new AddressesResponse();

            try
            {

                IProfileJsonAddressManager ProfileAddressMgr = new ProfileJsonAddressManager(_ProfileJson);
                IProfileAddress NewAddress = null;

                switch (addressType)
                {
                    case AddressTypes.Primary:
                        NewAddress = ProfileAddressMgr.Create(address1, address2, city, stateAbev, zipCode, true, false);
                        break;
                    case AddressTypes.Secondary:
                        NewAddress = ProfileAddressMgr.Create(address1, address2, city, stateAbev, zipCode, false, true);
                        break;
                }

                Response.Addresses.Add(NewAddress);
                Response.Success = true;

            }
            catch (Exception e) {
                Response.Success = false;

            }

            return Response;
        }

    }
}
