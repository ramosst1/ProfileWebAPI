using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileWebAPI.Models.Profiles
{
    public class ProfileAddressDto : AddressDto, IProfileAddress
    {

//        public int ProfileId { get; set; }
        public int AddressId { get; set; }


    }
}
