using Models.Profiles;
using Repositories.Models.Profiles;

namespace Services.Profiles.DataMapper
{
    public static class ProfileAddressDtoDataMapper
    {
        public static ProfileAddressModel MapData(this ProfileAddressDto profileAddress)
        {

            return new ProfileAddressModel()
            {
                Address1 = profileAddress.AddressName1,
                Address2 = profileAddress.AddressName2,
                City = profileAddress.City,
                StateAbrev = profileAddress.StateAbreviated,
                ZipCode = profileAddress.ZipCode,
                ProfileId = profileAddress.ProfileId,
                AddressId = profileAddress.AddressId,
                IsPrimary = profileAddress.IsPrimary,
                IsSecondary = profileAddress.IsSecondary
            };
        }
    }
}
