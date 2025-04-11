using Models.Profiles;
using Repositories.Models.Profiles;

namespace Services.Profiles.DataMapperExtensions
{
    public static class ProfileAddressCreateModelDataMapperExtension
    {

        public static List<ProfileAddressCreateDto> MapDataAsProfileAddressCreateDto(this List<ProfileAddressCreateModel> profile)
        {
            var results = new List<ProfileAddressCreateDto>();
            results.AddRange(
                profile.Select(item => item.MapDataAsProfileAddressCreateDto())
            );

            return results;
        }

        private static ProfileAddressCreateDto MapDataAsProfileAddressCreateDto(this ProfileAddressCreateModel profileAddress)
        {

            return new ProfileAddressCreateDto()
            {
                Address1 = profileAddress.AddressName1,
                Address2 = profileAddress.AddressName2,
                City = profileAddress.City,
                StateAbrev = profileAddress.StateAbreviation,
                ZipCode = profileAddress.ZipCode,
                IsPrimary = profileAddress.IsPrimary,
                IsSecondary = profileAddress.IsSecondary
            };
        }
    }
}
