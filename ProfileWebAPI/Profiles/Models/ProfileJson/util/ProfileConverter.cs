using Profiles.Models.Profiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Linq;
using AutoMapper;

namespace Profiles.Models.ProfileJson.util
{
    class ProfileConverter: IProfileConverter
    {
        public string ConvertToJson(List<IProfileJson> profiles)
        {

            var ListProfileNew = new List<ProfileJsonSerialized>();

            string Results = "";

            profiles.ForEach(delegate (IProfileJson aProfileJson)
            {
                ListProfileNew.Add(new ProfileJsonSerialized()
                {
                    Active = aProfileJson.Active,
                    Addresses = aProfileJson.Addresses,
                    FirstName = aProfileJson.FirstName,
                    LastName = aProfileJson.LastName,
                    ProfileId = aProfileJson.ProfileId

                });
            });


            using (MemoryStream stream1 = new MemoryStream())
            {
                var ser = new DataContractJsonSerializer(typeof(List<ProfileJsonSerialized>));

                ser.WriteObject(stream1, ListProfileNew);
                stream1.Position = 0;


                using (StreamReader sr = new StreamReader(stream1))
                {

                    Results = sr.ReadToEnd();
                }

            }

            return Results;
        }

        public IProfile Convert(IProfileJson aProfile)
        {

            aProfile.Addresses.ForEach(delegate (ProfileAddressJson profileAddress)
            {
                profileAddress.IsPrimary = profileAddress.AddressType == 1 ? true : false;
                profileAddress.IsSecondary = profileAddress.AddressType == 2 ? true : false;

            });

            if (aProfile == null) return null;

            var MapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<IProfileJson, Profiles.Profile>();
                cfg.CreateMap<ProfileAddressJson, Profiles.ProfileAddress>();
            });

            IMapper iMapper = MapperConfig.CreateMapper();

            var Results = iMapper.Map<IProfileJson, Profiles.Profile>(aProfile);

            return Results;



        }

        public List<IProfile> Convert(List<IProfileJson> profilelist)
        {

            var Profilelist = new List<IProfile>();


            profilelist.ForEach(delegate (IProfileJson aProfile)
            {

                Profilelist.Add(Convert(aProfile));

            });


            return Profilelist;

        }

        public List<ProfileAddressJson> Convert(List<IProfileAddress> addresses)
        {
            var Results = new List<ProfileAddressJson>();

            addresses.ForEach(delegate (IProfileAddress aProfileAddress)
            {
                Results.Add(Convert(aProfileAddress));
            });

            return Results;

        }

        public ProfileAddressJson Convert(IProfileAddress addresses)
        {
            int AddressType = 0;

            if (addresses.IsPrimary == true)
            {
                AddressType = 1;
            }
            else if (addresses.IsSecondary == true) {
                AddressType = 2;
            }

            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<IProfileAddress, ProfileAddressJson>()
                .ForMember(dest => dest.AddressType, sorc => sorc.MapFrom(map => AddressType ))
            );

            var mapper = new Mapper(config);
            var  Results = mapper.Map<ProfileAddressJson>(addresses);

            return Results;

        }


    }
}
