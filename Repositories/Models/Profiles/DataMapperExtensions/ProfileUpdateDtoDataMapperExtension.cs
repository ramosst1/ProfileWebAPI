namespace Repositories.Models.Profiles.DataMapperExtensions
{
    public static class ProfileUpdateDtoDataMapperExtension
    {
        public static ProfileDto MapDataAsProfileDto(this ProfileUpdateDto profile)
        {

            return new ProfileDto()
            {
                ProfileId = profile.ProfileId,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Active = profile.Active,
                Addresses = profile.Addresses.MapDataAsProfileAddressUpdateDto()
            };
        }
    }
}
