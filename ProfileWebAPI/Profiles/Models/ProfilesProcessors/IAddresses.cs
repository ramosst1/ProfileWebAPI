using System;
using System.Collections.Generic;
using System.Text;

namespace Profiles.Models.Profiles
{
    public interface IAddresses
    {
        List<IProfileAddress> Addresses { get; set; }

    }
}
