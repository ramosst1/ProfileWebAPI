using Newtonsoft.Json;
using Repositories.Models.Profiles;
using Repositories.Util;
using Services.Util;

namespace Repositories.Profiles
{
    public class ProfileRepository : IProfileRepository
    {
        const string JSON_DATASOURCE = "../Repositories/JsonData/Profiles.json";

        private readonly IProfileDataSource _profileDataSource;

        public ProfileRepository(IProfileDataSource profileDataSource )
        {
            _profileDataSource = profileDataSource;
        }

        public async Task<List<ProfileDto>> GetProfilesAsync()
        {

            return await _profileDataSource.GetProfilesAsync();
        }

        public async Task<ProfileDto> GetProfileByIdAsync(int profileId)
        {
            var result = await _profileDataSource.GetProfilesAsync();

            return result.FirstOrDefault(aItem => aItem.ProfileId == profileId);

        }
        public async Task<ProfileDto> CreateProfileAsync(ProfileCreateDto aProfile)
        {
            var profileList = await _profileDataSource.GetProfilesAsync();

            var profileId = profileList.Max(aItem => aItem.ProfileId) + 1;

            var newProfile = new ProfileDto();

            newProfile.ProfileId = profileId;
            newProfile.FirstName = aProfile.FirstName;
            newProfile.LastName = aProfile.LastName;
            newProfile.Active = aProfile.Active;

            var newAddresses = ProfileAddressConverter.Convert(aProfile.Addresses);

            var addressMaxId = GetMaxAddressId(profileList);

            newAddresses.ForEach(delegate (ProfileAddressDto aAddress)
            {
                aAddress.ProfileId = profileId;
                aAddress.AddressId = addressMaxId;
                addressMaxId++;
            });


            newProfile.Addresses = newAddresses;

            profileList.Add(newProfile);

            var profileNewList = JsonObjectConverter.ConvertToJson(profileList);

            await _profileDataSource.WriteJsonToFileAsync(profileNewList);

            return newProfile;
        }

        public async Task<bool> DeleteProfileAsync(int profileId)
        {
            var profilesList = await _profileDataSource.GetProfilesAsync();

            var profileListNew = profilesList.Where(existProfile => profileId != existProfile.ProfileId)
                .ToList();

            await _profileDataSource.WriteJsonToFileAsync(JsonObjectConverter.ConvertToJson(profileListNew));

            return true;
        }

        public async Task<ProfileDto> UpdateProfileAsync(ProfileUpdateDto profile)
        {

            var profileList = await _profileDataSource.GetProfilesAsync();

            var currentProfile = profileList.Where(aItem => aItem.ProfileId == profile.ProfileId).FirstOrDefault();

            if (currentProfile == null) return null;

            currentProfile.FirstName = profile.FirstName;
            currentProfile.LastName = profile.LastName;
            currentProfile.Active = profile.Active;

            currentProfile.Addresses = ProfileAddressConverter.Convert(profile.Addresses);

            var profileUpdateList = JsonObjectConverter.ConvertToJson(profileList);

            await _profileDataSource.WriteJsonToFileAsync(profileUpdateList);

            return currentProfile;

        }


        private static int GetMaxAddressId(List<ProfileDto> profiles) {

            var nextAddressId = profiles.SelectMany(aItem => aItem.Addresses).Max(aItem => aItem.AddressId) + 1;
                
            return nextAddressId;
        }
    }
}
