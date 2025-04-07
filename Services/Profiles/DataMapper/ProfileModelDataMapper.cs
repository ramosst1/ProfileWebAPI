using Models.Profiles;
using Repositories.Models.Profiles;

namespace Services.Profiles.DataMapper
{
    public static class ProfileModelDataMapper
    {
        public static List<ProfileModel> MapData(this List<ProfileDto> profile)
        {
            var results = new List<ProfileModel>();

            results.AddRange(
                profile.Select(item => MapData(item))
            );

            return results;
        }

        public static List<ProfileDto> MapData(this List<ProfileModel> profile)
        {
            var results = new List<ProfileDto>();
            results.AddRange(
                profile.Select(item => MapData(item))
            );

            return results;
        }

        private static ProfileModel MapData(this ProfileDto profile)
        {

            return new ProfileModel()
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Active = profile.Active,
                ProfileId = profile.ProfileId,
                Addresses = profile.Addresses.MapData()
            };
        }

        private static ProfileDto MapData(this ProfileModel profile)
        {

            return new ProfileDto()
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
