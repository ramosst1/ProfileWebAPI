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
                AddressName1 = profileAddress.Address1,
                AddressName2 = profileAddress.Address2,
                City = profileAddress.City,
                StateAbreviated = profileAddress.StateAbrev,
                ZipCode = profileAddress.ZipCode,
                ProfileId = profileAddress.ProfileId,
                AddressId = profileAddress.AddressId,
                IsPrimary = profileAddress.IsPrimary,
                IsSecondary = profileAddress.IsSecondary
            };
        }
    }
}
