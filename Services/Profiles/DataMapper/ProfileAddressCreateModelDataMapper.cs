using Models.Profiles;
using Repositories.Models.Profiles;

namespace Services.Profiles.DataMapper
{
    public static class ProfileAddressCreateModelDataMapper
    {

        public static List<ProfileAddressCreateDto> MapData(this List<ProfileAddressCreateModel> profile)
        {
            var results = new List<ProfileAddressCreateDto>();
            results.AddRange(
                profile.Select(item => MapData(item))
            );

            return results;
        }


        private static ProfileAddressCreateDto MapData(this ProfileAddressCreateModel profileAddress)
        {

            return new ProfileAddressCreateDto()
            {
                AddressName1 = profileAddress.Address1,
                AddressName2 = profileAddress.Address2,
                City = profileAddress.City,
                StateAbreviated = profileAddress.StateAbrev,
                ZipCode = profileAddress.ZipCode,
                IsPrimary = profileAddress.IsPrimary,
                IsSecondary = profileAddress.IsSecondary
            };
        }
    }
}
