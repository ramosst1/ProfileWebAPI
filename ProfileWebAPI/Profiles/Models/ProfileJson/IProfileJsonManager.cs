using System;
using System.Collections.Generic;
using System.Text;

namespace Profiles.Models.ProfileJson
{
    interface IProfileJsonManager: IProfileManager
    {
        List<IProfileJson> GetJsonProfiles();
        IProfileJson GetJsonProfileByProfileId(int profileId);
    }
}
