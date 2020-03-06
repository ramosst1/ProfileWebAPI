using System;
using System.Collections.Generic;
using System.Text;
using Profiles.Models.Profiles;

namespace Profiles.Models.ProfileJson
{
    public class AddressPopulateSecondaryJson : IAddressPopulate
    {
        private readonly IProfileManager _ProfileManager;
        private readonly IProfile _Profile;
        private readonly IAddressDataPopulate _AddressCrudData = null;

        public AddressPopulateSecondaryJson(IProfileManager aProfileManager, IProfile profile)
        {
            _ProfileManager = aProfileManager;
            _Profile = profile;
            _AddressCrudData = new AddressPopulate(_ProfileManager, _Profile);

        }

        public IProfileAddress Populate(
            int? addressId, string address1, string address2, string city, string stateAbev, string zipCode
        )
        {
            var UsertAddressAddres = _AddressCrudData.PopulateUpSertAddress(
                addressId, address1, address2, city, stateAbev, zipCode, false, true
            );

            return UsertAddressAddres;

        }
    }
}
