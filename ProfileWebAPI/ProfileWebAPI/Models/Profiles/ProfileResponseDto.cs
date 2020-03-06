using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileWebAPI.Models.Profiles
{
    public class ProfileResponse: APIResponseDto, IProfileResponse
    {
        public IProfile Profile { get; set; } 

    }
}
