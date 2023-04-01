using AutoMapper;
using Repositories.Models.Profiles;

namespace Services.Util
{
    public class ProfileAddressConverter
    {
        private ProfileAddressConverter()
        {
            
        }
        public static List<ProfileAddressDto> Convert(List<ProfileAddressCreateDto> profilesAddress)
        {
            var addressessConverted = new List<ProfileAddressDto>();

            profilesAddress.ForEach(selectedProfile =>
                addressessConverted.Add(Convert(selectedProfile))
            );

            return addressessConverted;
        }

        private static ProfileAddressDto Convert(ProfileAddressCreateDto profileAddress)
        {

            if (profileAddress == null) return null;

            var MapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProfileAddressCreateDto, ProfileAddressDto>();
            });

            IMapper iMapper = MapperConfig.CreateMapper();

            var results = iMapper.Map<ProfileAddressCreateDto, ProfileAddressDto>(profileAddress);

            return results;
        }

        public static List<ProfileAddressDto> Convert(List<ProfileAddressUpdateDto> profilesAddress)
        {
            var addressessConverted = new List<ProfileAddressDto>();

            profilesAddress.ForEach(selectedProfile =>
                addressessConverted.Add(Convert(selectedProfile))
            );

            return addressessConverted;
        }

        private static ProfileAddressDto Convert(ProfileAddressUpdateDto profileAddress)
        {

            if (profileAddress == null) return null;

            var MapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProfileAddressUpdateDto, ProfileAddressDto>();
            });

            IMapper iMapper = MapperConfig.CreateMapper();

            var results = iMapper.Map<ProfileAddressUpdateDto, ProfileAddressDto>(profileAddress);

            return results;
        }
    }
}
