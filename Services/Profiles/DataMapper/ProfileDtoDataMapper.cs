using Models.Profiles;
using Repositories.Models.Profiles;

namespace Services.Profiles.DataMapper
{
    public static class ProfileDtoDataMapper
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
