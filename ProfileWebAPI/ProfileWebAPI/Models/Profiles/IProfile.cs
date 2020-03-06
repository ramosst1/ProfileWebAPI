using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileWebAPI.Models.Profiles
{
    public interface IProfile: IProfileBase
    {
        int ProfileId { get; set; }

        List<ProfileAddressDto> Addresses { get; set; } 


    }
}
