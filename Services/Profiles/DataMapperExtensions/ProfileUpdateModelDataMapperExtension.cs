using Models.Profiles;
using Repositories.Models.Profiles;

namespace Services.Profiles.DataMapperExtensions
{
    public static class ProfileUpdateModelDataMapperExtension
    {

        public static ProfileUpdateDto MapDataAsProfileUpdateDto(this ProfileUpdateModel profile)
        {

            return new ProfileUpdateDto()
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Active = profile.Active,
                ProfileId = profile.ProfileId,
                Addresses = profile.Addresses.MapDataAsProfileAddressUpdateDto()
            };
        }

    }
}
