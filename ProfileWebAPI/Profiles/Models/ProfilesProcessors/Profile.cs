using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profiles.Models.Profiles
{
    public class Profile : IProfile, IAddresses
    {

        public int ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool Active { get; set; }

        public List <IProfileAddress> Addresses { get; set; } = new List<IProfileAddress>();

        public IProfileAddressManager ProfileAddressesMgr { get => new ProfileAddressManager(this); }

    }
}
