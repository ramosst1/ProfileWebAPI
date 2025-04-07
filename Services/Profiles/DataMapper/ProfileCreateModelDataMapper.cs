using Models.Profiles;
using Repositories.Models.Profiles;

namespace Services.Profiles.DataMapper
{
    public static class ProfileCreateModelDataMapper
    {

        public static ProfileCreateDto MapDataAsProfileCreateDto(this ProfileCreateModel profile)
        {

            return new ProfileCreateDto()
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Active = profile.Active,
                Addresses = profile.Addresses.MapDataAsProfileAddressCreateDto()
            };

        }

    }
}
