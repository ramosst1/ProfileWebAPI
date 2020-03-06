using System;
using System.Collections.Generic;
using System.Text;

namespace Profiles.Models.Profiles
{
    public interface IProfileBase
    {
        bool Active { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
//        int ProfileId { get; set; }

    }
}
