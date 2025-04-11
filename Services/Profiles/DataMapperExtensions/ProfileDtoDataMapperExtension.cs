using Models.Profiles;
using Repositories.Models.Profiles;

namespace Services.Profiles.DataMapperExtensions
{
    public static class ProfileDtoDataMapperExtension
    {

        public static ProfileModel MapDataAsProfileModel(this ProfileDto profile)
        {
            return new ProfileModel()
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Active = profile.Active,
                ProfileId = profile.ProfileId,
                Addresses = profile.Addresses.MapDataAsProfileAddressModel()
            };
        }


    }
}
