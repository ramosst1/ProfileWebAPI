namespace Repositories.Models.Profiles.DataMapperExtensions
{
    public static class ProfileCreateDtoDataMapperExtension
    {

        public static ProfileDto MapDataAsProfileDto(this ProfileCreateDto profile)
        {

            return new ProfileDto()
            {
                ProfileId = 0,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Active = profile.Active,
                Addresses = profile.Addresses.MapDataAsProfileAddressCreateDto()
            };
        }

    }
}
