using Profiles;
using ProfileWebAPI.Models.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileWebAPI.ProfilesProcessors
{
    public class ProfileProcessorManager : IProfileProcessorManager
    {

        private IProfileManager _ProfileManager { get; }

        public ProfileProcessorManager(IProfileManager profileManager)
        {
            _ProfileManager = profileManager;

        }

        public IProfileResponse UpdateProfile(IProfile profile)
        {

            IProfileResponse Response = new ProfileResponse();


            var AProfileToUpdateResponse = _ProfileManager.GetProfileById(profile.ProfileId);

            if (AProfileToUpdateResponse.Success == true)
            {

                var ExistingProfile = AProfileToUpdateResponse.Profile;

                ExistingProfile.FirstName = profile.FirstName;
                ExistingProfile.LastName = profile.LastName;
                ExistingProfile.Active = profile.Active;

                var AProfileAddressMgr = ExistingProfile.ProfileAddressesMgr;

                var NewProfileAddressDto = profile.Addresses.Where(aItem => aItem.AddressId == 0).ToList();
                var ExistingProfileAddressDto = profile.Addresses.Where(aItem => aItem.AddressId != 0);

                AProfileToUpdateResponse.Profile.Addresses.ForEach(delegate (Profiles.Models.Profiles.IProfileAddress aAddressToUpdate)
                {

                    var AProfileAddressDto = ExistingProfileAddressDto.FirstOrDefault(aItem => aItem.AddressId == aAddressToUpdate.AddressId);

                    if (AProfileAddressDto != null)
                    {

                        aAddressToUpdate.IsPrimary = AProfileAddressDto.IsPrimary;
                        aAddressToUpdate.IsSecondary = AProfileAddressDto.IsSecondary;
                        aAddressToUpdate.Address1 = AProfileAddressDto.Address1;
                        aAddressToUpdate.Address2 = AProfileAddressDto.Address2;
                        aAddressToUpdate.City = AProfileAddressDto.City;
                        aAddressToUpdate.StateAbrev = AProfileAddressDto.StateAbrev;
                        aAddressToUpdate.ZipCode = AProfileAddressDto.ZipCode;
                    }
                });

                var AProfileResponse = _ProfileManager.UpdateProfile(ExistingProfile);


                if (AProfileResponse.Success == true && NewProfileAddressDto.Any())
                {

                    ExistingProfile = AProfileResponse.Profile;

                    NewProfileAddressDto.ForEach(delegate (ProfileAddressDto newAddress) {

                        Profiles.Models.APIResponses.IAddressesResponse AAddresssResponse = null;

                        if (newAddress.IsPrimary)
                        {

                            AAddresssResponse = AProfileAddressMgr.Create(
                                newAddress.Address1, newAddress.Address2, newAddress.City,
                                newAddress.StateAbrev, newAddress.ZipCode, Profiles.Models.Profiles.AddressTypes.Primary
                            );


                        }
                        else if (newAddress.IsSecondary == true)
                        {
                            AAddresssResponse = AProfileAddressMgr.Create(
                                newAddress.Address1, newAddress.Address2, newAddress.City,
                                newAddress.StateAbrev, newAddress.ZipCode, Profiles.Models.Profiles.AddressTypes.Secondary
                            );
                            ;
                        }

                        if (AAddresssResponse.Success == true)
                        {

                            ExistingProfile.Addresses.AddRange(AAddresssResponse.Addresses);

                        }
                    });


                }

                Response = Util.ProfileConverter.Convert(AProfileResponse);

            }
            else
            {

                Response.Profile = null;
                Response.Success = false;
            }


            return Response;

        }

        public IProfileResponse CreateProfile(IProfileNew aProfile) {

            IProfileResponse AProfileResponse;


            var NewProfile = _ProfileManager.CreateProfile(aProfile.FirstName, aProfile.LastName, aProfile.Active);

            if (NewProfile.Success == true)
            {

                var AProfileAddressMgr = NewProfile.Profile.ProfileAddressesMgr;

                aProfile.Addresses.ForEach(delegate (ProfileAddressNewDto newAddress) {

                    Profiles.Models.APIResponses.IAddressesResponse AAddresssResponse = null;

                    if (newAddress.IsPrimary)
                    {

                        AAddresssResponse = AProfileAddressMgr.Create(
                            newAddress.Address1, newAddress.Address2, newAddress.City,
                            newAddress.StateAbrev, newAddress.ZipCode, Profiles.Models.Profiles.AddressTypes.Primary
                        );


                    }
                    else if (newAddress.IsSecondary == true)
                    {
                        AAddresssResponse = AProfileAddressMgr.Create(
                            newAddress.Address1, newAddress.Address2, newAddress.City,
                            newAddress.StateAbrev, newAddress.ZipCode, Profiles.Models.Profiles.AddressTypes.Secondary
                        );
                        ;
                    }

                    if (AAddresssResponse.Success == true)
                    {

                        NewProfile.Profile.Addresses.AddRange(AAddresssResponse.Addresses);

                    }
                });


            }
            AProfileResponse = Util.ProfileConverter.Convert(NewProfile);

            return AProfileResponse;

        }
    }
}
