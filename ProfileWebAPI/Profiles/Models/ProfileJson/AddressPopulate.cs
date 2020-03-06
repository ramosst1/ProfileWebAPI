using Profiles.Models.Profiles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Profiles.Models.ProfileJson
{
    class AddressPopulate : IAddressDataPopulate
    {

        private readonly IProfileManager _ProfileManager;
        private readonly IProfile _Profile;
        public AddressPopulate(IProfileManager aProfileManger, IProfile profile)
        {
            _ProfileManager = aProfileManger;
            _Profile = profile;
        }

        public IProfileAddress PopulateUpSertAddress(
            int? addressId, string address1, string address2,
            string city, string stateAbev,
            string zipCode, bool isPrimary, bool isSecondary = false
        )
        {

            var ExitingProfile = _ProfileManager.GetProfiles().Profiles
                    .FirstOrDefault(aItem => aItem.ProfileId == _Profile.ProfileId);

            var UserToAddressAddres = ExitingProfile?.
                    Addresses?.FirstOrDefault(aItem => aItem.AddressId == addressId && aItem.IsPrimary == isPrimary && aItem.IsSecondary == isSecondary);

            if (UserToAddressAddres == null)
            {
                UserToAddressAddres = new ProfileAddress();

                UserToAddressAddres.ProfileId = _Profile.ProfileId;
                UserToAddressAddres.AddressId = GetNextAddressID();
                UserToAddressAddres.IsPrimary = isPrimary;
                UserToAddressAddres.IsSecondary = isSecondary;
            }

            UserToAddressAddres.Address1 = address1;
            UserToAddressAddres.Address2 = address2;
            UserToAddressAddres.City = city;
            UserToAddressAddres.StateAbrev = stateAbev;
            UserToAddressAddres.ZipCode = zipCode;

            return UserToAddressAddres;
        }

        private int GetNextAddressID()
        {

            var Profiles = _ProfileManager.GetProfiles();
            var AddressList = new List<IProfileAddress>();
            foreach (IProfile existingProfile in Profiles.Profiles)
            {
                AddressList.AddRange(existingProfile.Addresses);
            }

            var NextAddressId = AddressList.Max(aItem => aItem.AddressId) + 1;

            return NextAddressId;


        }

    }
}
