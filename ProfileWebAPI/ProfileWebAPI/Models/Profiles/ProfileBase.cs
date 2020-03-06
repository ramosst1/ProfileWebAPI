using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileWebAPI.Models.Profiles
{
    public class ProfileBase: IProfileBase
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool Active { get; set; }


    }
}
