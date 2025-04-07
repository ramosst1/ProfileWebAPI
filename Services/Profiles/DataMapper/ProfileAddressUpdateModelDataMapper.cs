using Models.Profiles;
using Repositories.Models.Profiles;

namespace Services.Profiles.DataMapper
{
    public static class ProfileAddressUpdateModelDataMapper
    {

        public static List<ProfileAddressUpdateDto> MapDataAsProfileAddressUpdateDto(this List<ProfileAddressUpdateModel> profileAddress)
        {
            var results = new List<ProfileAddressUpdateDto>();

            results.AddRange(
                profileAddress.Select(item => MapDataAsProfileAddressUpdateDto(item))
            );

            return results;
        }
        
        private static ProfileAddressUpdateDto MapDataAsProfileAddressUpdateDto(this ProfileAddressUpdateModel profileAddress)
        {

            return new ProfileAddressUpdateDto()
            {
                Address1 = profileAddress.AddressName1,
                Address2 = profileAddress.AddressName2,
                City = profileAddress.City,
                StateAbrev = profileAddress.StateAbreviation,
                ZipCode = profileAddress.ZipCode,
                ProfileId = profileAddress.ProfileId,
                AddressId = profileAddress.AddressId,
                IsPrimary = profileAddress.IsPrimary,
                IsSecondary = profileAddress.IsSecondary
            };
        }
    }
}
