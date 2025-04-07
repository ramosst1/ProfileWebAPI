﻿using Models.Profiles;
using Repositories.Models.Profiles;

namespace Services.Profiles.DataMapper
{
    public static class ProfileAddressModelDataMapper
    {

        public static  List<ProfileAddressModel> MapData(this List<ProfileAddressDto> profileAddress)
        {
            var results = new List<ProfileAddressModel>();

            results.AddRange(
                profileAddress.Select(item => MapData(item))
            );

            return results;
        }

        public static List<ProfileAddressDto> MapData(this List<ProfileAddressModel> profileAddress)
        {
            var results = new List<ProfileAddressDto>();
            results.AddRange(
                profileAddress.Select(item => MapData(item))
            );

            return results;
        }

        private static ProfileAddressModel MapData(this ProfileAddressDto profileAddress)
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

        private static ProfileAddressDto MapData(this ProfileAddressModel profileAddress)
        {

            return new ProfileAddressDto()
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
