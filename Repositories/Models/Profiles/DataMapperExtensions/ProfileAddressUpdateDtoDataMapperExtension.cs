
namespace Repositories.Models.Profiles.DataMapperExtensions
{
    public static class ProfileAddressUpdateDtoDataMapperExtension
    {

        public static List<ProfileAddressDto> MapDataAsProfileAddressUpdateDto(this List<ProfileAddressUpdateDto> profileAddress)
        {
            var results = new List<ProfileAddressDto>();
            results.AddRange(
                profileAddress.Select(item => item.MapDataAsProfileAddressUpdateDto())
            );

            return results;
        }

        private static ProfileAddressDto MapDataAsProfileAddressUpdateDto(this ProfileAddressUpdateDto profileAddress)
        {

            return new ProfileAddressDto()
            {
                AddressId = profileAddress.AddressId,
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
