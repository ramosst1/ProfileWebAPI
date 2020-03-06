using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profiles.Models.Profiles
{
    public class ProfileAddress : Address, IProfileAddress
    {

        public int ProfileId { get; set; }
        public int AddressId { get; set; }
        public bool IsPrimary { get; set; } = false;
        public bool IsSecondary { get; set; } = false;

    }
}
