using Repositories.Models.Profiles;
using System.Runtime.Serialization.Json;

namespace Repositories.Util
{
    public class JsonObjectConverter
    {

        public static string ConvertToJson(List<ProfileDto> profiles)
        {

            var ListProfileNew = new List<ProfileDto>();

            string Results = "";

            profiles.ForEach(delegate (ProfileDto aProfileJson)
            {
                ListProfileNew.Add(new ProfileDto()
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
                var ser = new DataContractJsonSerializer(typeof(List<ProfileDto>));

                ser.WriteObject(stream1, ListProfileNew);
                stream1.Position = 0;


                using (StreamReader sr = new StreamReader(stream1))
                {

                    Results = sr.ReadToEnd();
                }

            }

            return Results;
        }

    }
}
