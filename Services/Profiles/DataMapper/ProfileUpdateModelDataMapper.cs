using Models.Profiles;
using Repositories.Models.Profiles;

namespace Services.Profiles.DataMapper
{
    public static class ProfileUpdateModelDataMapper
    {

        public static ProfileUpdateDto MapData(this ProfileUpdateModel profile)
        {

            return new ProfileUpdateDto()
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Active = profile.Active,
                ProfileId = profile.ProfileId,
                Addresses = profile.Addresses.MapData()
            };
        }

    }
}
