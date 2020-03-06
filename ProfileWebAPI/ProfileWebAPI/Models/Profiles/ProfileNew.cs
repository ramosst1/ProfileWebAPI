using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileWebAPI.Models.Profiles
{
    public class ProfileNew : ProfileBase, IProfileNew
    {
        public List<ProfileAddressNewDto> Addresses { get; set; } = new List<ProfileAddressNewDto>();
    }
}
