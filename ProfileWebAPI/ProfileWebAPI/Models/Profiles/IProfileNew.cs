using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileWebAPI.Models.Profiles
{
    public interface IProfileNew: IProfileBase
    {
        List<ProfileAddressNewDto> Addresses { get; set; }

    }
}
