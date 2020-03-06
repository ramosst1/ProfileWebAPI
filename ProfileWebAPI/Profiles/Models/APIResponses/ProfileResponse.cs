using System;
using System.Collections.Generic;
using System.Text;
using Profiles.Models.Profiles;

namespace Profiles.Models.APIResponses
{
    public class ProfileResponse : ResponseBase, IProfileResponse
    {
        public IProfile Profile { get ; set; }
    }
}
