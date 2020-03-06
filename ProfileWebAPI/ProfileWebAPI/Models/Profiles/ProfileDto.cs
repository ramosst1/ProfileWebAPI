using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileWebAPI.Models.Profiles
{
    public class ProfileDto : ProfileBase, IProfile
    {
        public int ProfileId { get; set; }

        public List<ProfileAddressDto> Addresses { get; set; } = new List<ProfileAddressDto>();

    }
}
