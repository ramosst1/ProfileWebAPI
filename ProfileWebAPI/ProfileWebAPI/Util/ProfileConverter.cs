using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Profiles;
using WebAPIModel = ProfileWebAPI.Models.Profiles ;
using ProfileModel = Profiles.Models;
using ProfileAPI  = Profiles.Models.APIResponses;
using WebApiModel = ProfileWebAPI.Models.Profiles;
using AutoMapper;

namespace ProfileWebAPI.Util
{
    public class ProfileConverter
    {

        public static WebApiModel.IProfileResponse Convert(ProfileAPI.IProfileResponse aProfileResponse) {

            WebApiModel.IProfileResponse Response = new WebApiModel.ProfileResponse() {
                Profile = Convert(aProfileResponse.Profile),
                Success = aProfileResponse.Success,
                ErrorMessages = Convert(aProfileResponse.Messages)
            };

            return Response;
        }

        public static WebApiModel.IProfilesResponse Convert(ProfileAPI.IProfilesResponse aProfileResponse)
        {

            WebApiModel.IProfilesResponse Response = new WebApiModel.ProfilesResponse()
            {
                Profiles = Convert(aProfileResponse.Profiles),
                Success = aProfileResponse.Success,
                ErrorMessages = Convert(aProfileResponse.Messages)

            };

            return Response;
        }

        private static List <WebAPIModel.IProfile> Convert(List <ProfileModel.Profiles.IProfile> profiles) {

            List <WebApiModel.IProfile> Profiles = new List<WebApiModel.IProfile>();

            profiles.ForEach(selectedProfile =>
                Profiles.Add(Convert(selectedProfile))
            
            );

            return Profiles;
        }

        private static WebAPIModel.IProfile Convert(ProfileModel.Profiles.IProfile aProfile) {

            if(aProfile == null) return null;

            var MapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProfileModel.Profiles.IProfile, WebAPIModel.ProfileDto>();
                cfg.CreateMap<ProfileModel.Profiles.IProfileAddress, WebAPIModel.ProfileAddressDto>();
            });

            IMapper iMapper = MapperConfig.CreateMapper();

            var Results = iMapper.Map<ProfileModel.Profiles.IProfile, WebAPIModel.ProfileDto>(aProfile);

            return Results;



        }

        private static List<Models.IErrorMessage> Convert(List<ProfileModel.APIResponses.IErrorMessage> errorMessages)
        {

            var MapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProfileModel.APIResponses.IErrorMessage, Models.ErrorMessageDto>()
                .ForMember(d => d.Message, opt => opt.MapFrom(src => src.InternalMessage));
            });

            IMapper iMapper = MapperConfig.CreateMapper();

            var Results = iMapper.Map<List <ProfileModel.APIResponses.IErrorMessage>, List <Models.ErrorMessageDto>>(errorMessages);

            return Results.Cast<Models.IErrorMessage>().ToList();

    }


    }
}
