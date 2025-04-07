using Repositories.Models.Profiles;
using Utilities.Converters.JsonObjectConverter;

namespace Repositories.Profiles
{
    public class ProfileDataJsonSource : IProfileDataSource
    {
        const string JSON_DATASOURCE = "../Repositories/JsonData/Profiles.json";

        async Task<List<ProfileDto>> IProfileDataSource.GetProfilesAsync()
        {
            List<ProfileDto> profileList = new List<ProfileDto>();

            await Task.Run(() =>
            {
                profileList = GetProfiles();
            });

            return profileList;
        }

        private static List<ProfileDto> GetProfiles()
        {
            List<ProfileDto> profileList = new List<ProfileDto>();

            var profilesJson = ReadFromStreamReader(JSON_DATASOURCE);

            profileList = ConvertJsonToObject<List<ProfileDto>>(profilesJson)
                .OrderBy(aItem => $"{aItem.LastName}{aItem.FirstName}")
                .ToList();

            return profileList;
        }

        async Task IProfileDataSource.WriteJsonToFileAsync(string jsonContent)
        {
            await Task.Run(() => {
                WriteJsonToFile(jsonContent);
            });
        }

        private static string ReadFromStreamReader(string filePathSource)
        {
            using (StreamReader r = new StreamReader(filePathSource))
            {
                return r.ReadToEnd();
            }
        }


        private static void WriteJsonToFile(string jsonContent)
        {

            System.IO.File.WriteAllText(JSON_DATASOURCE, jsonContent);
        }

        private static TObject ConvertJsonToObject<TObject>(string json)
        {
            var response = JsonConverter.Convert<TObject>(json);

            return response;
        }

    }
}
