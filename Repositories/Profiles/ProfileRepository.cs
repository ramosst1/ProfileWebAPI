using Repositories.Models.Profiles;
using Utilities.Converters.JsonObjectConverter;
using Utilities.Converters.ObjectConverter;

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

            var newAddresses = Convert<List<ProfileAddressCreateDto>, List<ProfileAddressDto>>(aProfile.Addresses);

            var addressMaxId = GetMaxAddressId(profileList);

            newAddresses.ForEach(delegate (ProfileAddressDto aAddress)
            {
                aAddress.ProfileId = profileId;
                aAddress.AddressId = addressMaxId;
                addressMaxId++;
            });


            newProfile.Addresses = newAddresses;

            profileList.Add(newProfile);

            var profileNewList = ConvertToJson<List<ProfileDto>>(profileList);

            await _profileDataSource.WriteJsonToFileAsync(profileNewList);

            return newProfile;
        }

        public async Task<bool> DeleteProfileAsync(int profileId)
        {
            var profilesList = await _profileDataSource.GetProfilesAsync();

            var profileListNew = profilesList.Where(existProfile => profileId != existProfile.ProfileId)
                .ToList();

            await _profileDataSource.WriteJsonToFileAsync(ConvertToJson<List<ProfileDto>>(profileListNew));

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

            currentProfile.Addresses = Convert<List<ProfileAddressUpdateDto>, List<ProfileAddressDto>>(profile.Addresses);

            var profileUpdateList = ConvertToJson<List<ProfileDto>>(profileList);

            await _profileDataSource.WriteJsonToFileAsync(profileUpdateList);

            return currentProfile;
        }

        private static int GetMaxAddressId(List<ProfileDto> profiles) {

            var nextAddressId = profiles.SelectMany(aItem => aItem.Addresses).Max(aItem => aItem.AddressId) + 1;
                
            return nextAddressId;
        }

        private static TTarget Convert<TSource, TTarget>(TSource source)
        {
            var response = DataMapperConverter.Convert<TSource, TTarget>(source);

            return response;
        }

        private static string ConvertToJson<TObject>(TObject source)
        {
            var response = JsonConverter.Convert<TObject>(source);

            return response;
        }

    }
}
