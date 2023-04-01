using Newtonsoft.Json;
using Repositories.Models.Profiles;

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

            using (StreamReader r = new StreamReader(JSON_DATASOURCE))
            {
                string json = r.ReadToEnd();
                var ProfileJson = JsonConvert.DeserializeObject<List<ProfileDto>>(json);

                profileList = ProfileJson.Cast<ProfileDto>().OrderBy(aItem => $"{aItem.LastName}{aItem.FirstName}").ToList();

            }

            return profileList;
        }

        async Task IProfileDataSource.WriteJsonToFileAsync(string jsonContent)
        {
            await Task.Run(() => {
                WriteJsonToFile(jsonContent);
            });
        }

        private static void WriteJsonToFile(string jsonContent)
        {

            System.IO.File.WriteAllText(JSON_DATASOURCE, jsonContent);
        }

    }
}
