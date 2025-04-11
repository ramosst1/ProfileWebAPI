namespace Repositories.Models.Profiles.DataMapperExtensions
{
    public static class ProfileAddressCreateDtoDataMapperExtension
    {

        public static List<ProfileAddressDto> MapDataAsProfileAddressCreateDto(this List<ProfileAddressCreateDto> profileAddress)
        {
            var results = new List<ProfileAddressDto>();
            results.AddRange(
                profileAddress.Select(item => item.MapDataAsProfileAddressCreateDto())
            );

            return results;
        }

        private static ProfileAddressDto MapDataAsProfileAddressCreateDto(this ProfileAddressCreateDto profileAddress)
        {

            return new ProfileAddressDto()
            {
                AddressId = 0,
                Address1 = profileAddress.Address1,
                Address2 = profileAddress.Address2,
                City = profileAddress.City,
                StateAbrev = profileAddress.StateAbrev,
                ZipCode = profileAddress.ZipCode,
                IsPrimary = profileAddress.IsPrimary,
                IsSecondary = profileAddress.IsSecondary
            };
        }


    }
}
