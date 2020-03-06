using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileWebAPI.Models.Profiles
{
    public class ProfilesResponse : APIResponseDto, IProfilesResponse
    {
        public List<IProfile> Profiles { get; set; } = new List<IProfile>();

    }
}
