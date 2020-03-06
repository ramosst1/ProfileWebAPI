using Newtonsoft.Json;
using Profiles.Models.Profiles;
using Profiles.Models.APIResponses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using Profiles.Models.ProfileJson.util;

namespace Profiles.Models.ProfileJson
{
    public class ProfileJsonManager : IProfileManager, IProfileJsonManager
    {
        const string JSON_DATASOURCE = "../Profiles/JsonData/Profiles.json";

        private readonly IProfileConverter _ProfileConverter = new ProfileConverter();

        public ProfileJsonManager()
        {

        }

        public IProfilesResponse GetProfiles()
        {

            IProfilesResponse AProfileResponse = new ProfilesResponse();

            try
            {

                AProfileResponse.Profiles = _ProfileConverter.Convert(GetJsonProfiles());
                AProfileResponse.Success = true;

            }
            catch (Exception e)
            {
                AProfileResponse.Success = false;

            }

            return AProfileResponse;

        }

        public IProfileResponse CreateProfile(string firstName, string lastName, bool active)
        {

            IProfileResponse AProfileResponse = new ProfileResponse();

            try
            {
                var NextProfileId = (GetJsonProfiles().Max(aItem => aItem.ProfileId) + 1);
                
                var ProfileNew = new Profile()
                {
                    ProfileId = NextProfileId,
                    FirstName = firstName,
                    LastName = lastName,
                    Active = active
                };

                return UpSertProfile(ProfileNew);

            }
            catch (Exception e)
            {
                AProfileResponse.Success = false;
            }

            return AProfileResponse;
        }
        //public IProfileResponse CreateProfile(string firstName, string lastName, bool active, List<IProfileAddress> aProfileAddresses)
        //{

        //    IProfileResponse AProfileResponse = new ProfileResponse();

        //    try
        //    {
        //        var NextProfileId = (GetJsonProfiles().Max(aItem => aItem.ProfileId) + 1);

        //        var ProfileNew = new Profile()
        //        {
        //            ProfileId = NextProfileId,
        //            FirstName = firstName,
        //            LastName = lastName,
        //            Active = active,
        //            Addresses = aProfileAddresses
        //        };

        //        return UpSertProfile(ProfileNew);

        //    }
        //    catch (Exception e)
        //    {
        //        AProfileResponse.Success = false;
        //    }

        //    return AProfileResponse;
        //}

        public IProfileResponse DeleteProfiles(int profileId)
        {

            IProfileResponse AProfileResponse = new ProfileResponse();

            try
            {

                var ProfilesList = GetJsonProfiles().
                    Where(existProfile => profileId != existProfile.ProfileId)
                    .ToList();

                WriteJsonToFile(_ProfileConverter.ConvertToJson(ProfilesList));

                AProfileResponse.Success = true;

            }
            catch (Exception e) {
                AProfileResponse.Success = false;

            }

            return AProfileResponse;
        }

        public IProfileResponse GetProfileById(int profileId)
        {

            IProfileResponse AProfileResponse = new ProfileResponse();

            try
            {

                var AProfileJson = GetJsonProfileByProfileId(profileId);

                AProfileResponse.Profile = _ProfileConverter.Convert(AProfileJson);

                AProfileResponse.Success = true;

            }
            catch (Exception e) {
                AProfileResponse.Success = false;

            }

            return AProfileResponse;
       }

        public IProfileResponse UpdateProfile(IProfile aProfile)
        {

            return UpSertProfile(aProfile);

        }

        private IProfileResponse UpSertProfile(IProfile aProfile)
        {

            IProfileResponse AProfileResponse = new ProfileResponse();

            try
            {
                var ProfileList = GetJsonProfiles();

                var ProfileAddressNew = new List<IProfileAddress>();

                var SelectedProfile = ProfileList
                    .Where(aItem => aItem.ProfileId == aProfile.ProfileId)
                    .FirstOrDefault();

                if (SelectedProfile == null)
                {
                    SelectedProfile = new ProfileJson();
                    SelectedProfile.ProfileId = aProfile.ProfileId;

                    ProfileList.Add(SelectedProfile);
                }

                SelectedProfile.FirstName = aProfile.FirstName;
                SelectedProfile.LastName = aProfile.LastName;
                SelectedProfile.Active = aProfile.Active;

                aProfile.Addresses.ForEach(delegate (IProfileAddress aAddress)
                {

                    IAddressPopulate aAddressPopulate = null;

                    if (aAddress.IsPrimary == true)
                    {

                        aAddressPopulate = new AddressPopulatePrimaryJson(this, aProfile);
                    }
                    else if (aAddress.IsSecondary == true)
                    {

                        aAddressPopulate = new AddressPopulateSecondaryJson(this, aProfile);
                    }

                    IProfileAddress AAddressUpsert = aAddressPopulate.Populate(
                        aAddress.AddressId, aAddress.Address1, aAddress.Address2, aAddress.City, aAddress.StateAbrev, aAddress.ZipCode
                    );

                    var AddressConcrete = AAddressUpsert as ProfileAddress;

                    ProfileAddressNew.Add(AddressConcrete);


                });

                SelectedProfile.Addresses = _ProfileConverter.Convert(ProfileAddressNew);

                var ProfileNewList = _ProfileConverter.ConvertToJson(ProfileList);

                WriteJsonToFile(ProfileNewList);
                AProfileResponse.Profile = _ProfileConverter.Convert(SelectedProfile);
                AProfileResponse.Success = true;


            }
            catch (Exception e)
            {
                AProfileResponse.Success = false;

            }

            return AProfileResponse;
        }

        public List<IProfileJson> GetJsonProfiles()
        {

            List<IProfile> ProfileList = new List<IProfile>();

            using (StreamReader r = new StreamReader(JSON_DATASOURCE))
            {
                string json = r.ReadToEnd();
                var ProfileJson = JsonConvert.DeserializeObject<List<ProfileJson>>(json);

                return ProfileJson.Cast<IProfileJson>().OrderBy(aItem => $"{aItem.LastName}{aItem.FirstName}") .ToList();

            }

        }
        public IProfileJson GetJsonProfileByProfileId(int profileId) {

            return GetJsonProfiles().FirstOrDefault(aItem => aItem.ProfileId == profileId);
        }

        private static void WriteJsonToFile(string jsonContent)
        {

            System.IO.File.WriteAllText(JSON_DATASOURCE, jsonContent);
        }


    }
}
