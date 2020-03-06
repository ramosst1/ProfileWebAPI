using System.Collections.Generic;

namespace Profiles.Models.Profiles
{
    public interface IProfile: IProfileBase
    {
        int ProfileId { get; set; }
        List<IProfileAddress> Addresses { get; set; }

        IProfileAddressManager ProfileAddressesMgr { get;  }
    }
}