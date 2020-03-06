using System;
using System.Collections.Generic;
using System.Text;
using Profiles.Models.Profiles;

namespace Profiles.Models.APIResponses
{
    public class ProfilesResponse : ResponseBase , IProfilesResponse
    {
        public List<IProfile> Profiles { get ; set ; }
    }
}
