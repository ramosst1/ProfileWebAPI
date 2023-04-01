using AutoMapper;
using Models.Profiles;
using Repositories.Models.Profiles;

namespace Services.Util
{
    public class ProfileConverter
    {
        private ProfileConverter()
        {
            
        }

        public static List<ProfileModel> Convert(List<ProfileDto> profiles)
        {
            var profilesConverted = new List<ProfileModel>();

            profiles.ForEach(selectedProfile =>
                profilesConverted.Add(Convert(selectedProfile))
            );

            return profilesConverted;
        }

        public static ProfileModel Convert(ProfileDto aProfile)
        {

            if (aProfile == null) return null;

            var MapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProfileDto, ProfileModel>();
                cfg.CreateMap<ProfileAddressDto, ProfileAddressModel>();
            });

            IMapper iMapper = MapperConfig.CreateMapper();

            var results = iMapper.Map<ProfileDto, ProfileModel>(aProfile);

            return results;
        }

        public static ProfileDto Convert(ProfileCreateModel aProfile)
        {

            if (aProfile == null) return null;

            var MapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProfileCreateModel, ProfileDto>();
                cfg.CreateMap<ProfileAddressCreateModel, ProfileAddressDto>();
            });

            IMapper iMapper = MapperConfig.CreateMapper();

            var results = iMapper.Map<ProfileCreateModel, ProfileDto>(aProfile);

            return results;
        }

        public static ProfileCreateDto ConvertToNewDto(ProfileCreateModel aProfile)
        {

            if (aProfile == null) return null;

            var MapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProfileCreateModel, ProfileCreateDto>();
                cfg.CreateMap<ProfileAddressCreateModel, ProfileAddressCreateDto>();
            });

            IMapper iMapper = MapperConfig.CreateMapper();

            var results = iMapper.Map<ProfileCreateModel, ProfileCreateDto>(aProfile);

            return results;
        }

        public static ProfileUpdateDto ConvertToUpdateDto(ProfileUpdateModel aProfile)
        {

            if (aProfile == null) return null;

            var MapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProfileUpdateModel, ProfileUpdateDto>();
                cfg.CreateMap<ProfileAddressUpdateModel, ProfileAddressUpdateDto>();
            });

            IMapper iMapper = MapperConfig.CreateMapper();

            var results = iMapper.Map<ProfileUpdateModel, ProfileUpdateDto>(aProfile);

            return results;
        }

        public static ProfileDto Convert(ProfileUpdateModel aProfile)
        {

            if (aProfile == null) return null;

            var MapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProfileUpdateModel, ProfileDto>();
                cfg.CreateMap<ProfileAddressUpdateModel, ProfileAddressDto>();
            });

            IMapper iMapper = MapperConfig.CreateMapper();

            var results = iMapper.Map<ProfileUpdateModel, ProfileDto>(aProfile);

            return results;
        }
    }
}
