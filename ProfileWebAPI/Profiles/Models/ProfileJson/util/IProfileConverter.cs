using Profiles.Models.Profiles;
using System.Collections.Generic;
using System.Linq;

namespace Profiles.Models.ProfileJson.util
{
    public interface IProfileConverter
    {

        string ConvertToJson(List<IProfileJson> profiles);
        IProfile Convert(IProfileJson aProfile);

        List<IProfile> Convert(List<IProfileJson> profilelist);

        List<ProfileAddressJson> Convert(List<IProfileAddress> addresses);

        ProfileAddressJson Convert(IProfileAddress addresses);

    }
}