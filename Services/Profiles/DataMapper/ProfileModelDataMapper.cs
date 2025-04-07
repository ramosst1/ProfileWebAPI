using Models.Profiles;
using Repositories.Models.Profiles;

namespace Services.Profiles.DataMapper
{
    public static class ProfileModelDataMapper
    {
        public static List<ProfileModel> MapDataAsProfileModel(this List<ProfileDto> profile)
        {
            var results = new List<ProfileModel>();

            results.AddRange(
                profile.Select(item => MapDataAsProfileModel(item))
            );

            return results;
        }

        public static List<ProfileDto> MapDataAsProfileDto(this List<ProfileModel> profile)
        {
            var results = new List<ProfileDto>();
            results.AddRange(
                profile.Select(item => MapDataAsMapDataAsProfileDto(item))
            );

            return results;
        }

        private static ProfileModel MapDataAsProfileModel(this ProfileDto profile)
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

        private static ProfileDto MapDataAsMapDataAsProfileDto(this ProfileModel profile)
        {

            return new ProfileDto()
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Active = profile.Active,
                ProfileId = profile.ProfileId,
                Addresses = profile.Addresses.MapDataAsProfileAddressDto()
            };
        }
    }
}
