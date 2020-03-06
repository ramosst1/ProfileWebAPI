using Profiles.Models.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profiles.Models.Profiles
{
    public interface IAddressPopulate
    {
        IProfileAddress Populate(int? addressId, string address1, string address2, string city, string stateAbev, string zipCode);
    }
}
