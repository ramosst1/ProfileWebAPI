using Profiles.Models.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profiles.Models.APIResponses
{
    public class AddressesResponse : ResponseBase, IAddressesResponse
    {
        public List<IProfileAddress> Addresses { get; set; } = new List<IProfileAddress>();

    }

}
