using Profiles.Models.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profiles.Models.ProfileJson
{
    public class ProfileAddressJson : ProfileAddress, IProfileAddressJson
    {
        public int AddressType { get; set;  } = 0;
    }
}
