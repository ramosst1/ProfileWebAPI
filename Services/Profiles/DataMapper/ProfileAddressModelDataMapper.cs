using Models.Profiles;
using Repositories.Models.Profiles;

namespace Services.Profiles.DataMapper
{
    public static class ProfileAddressModelDataMapper
    {

        public static  List<ProfileAddressModel> MapDataAsProfileAddressModel(this List<ProfileAddressDto> profileAddress)
        {
            var results = new List<ProfileAddressModel>();

            results.AddRange(
                profileAddress.Select(item => MapDataAsProfileAddressModel(item))
            );

            return results;
        }

        public static List<ProfileAddressDto> MapDataAsProfileAddressDto(this List<ProfileAddressModel> profileAddress)
        {
            var results = new List<ProfileAddressDto>();
            results.AddRange(
                profileAddress.Select(item => MapDataAsProfileAddressDto(item))
            );

            return results;
        }

        private static ProfileAddressModel MapDataAsProfileAddressModel(this ProfileAddressDto profileAddress)
        {

            return new ProfileAddressModel()
            {
                AddressName1 = profileAddress.Address1,
                AddressName2 = profileAddress.Address2,
                City = profileAddress.City,
                StateAbreviation = profileAddress.StateAbrev,  
                ZipCode = profileAddress.ZipCode,
                ProfileId = profileAddress.ProfileId,
                AddressId = profileAddress.AddressId,
                IsPrimary = profileAddress.IsPrimary,
                IsSecondary = profileAddress.IsSecondary
            };
        }

        private static ProfileAddressDto MapDataAsProfileAddressDto(this ProfileAddressModel profileAddress)
        {

            return new ProfileAddressDto()
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
