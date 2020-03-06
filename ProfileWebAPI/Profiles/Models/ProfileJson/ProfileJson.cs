using Profiles.Models.Profiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace Profiles.Models.ProfileJson
{
    public class ProfileJson : IProfileJson
    {
        public int ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }
        public bool IsPrimary { get; set; } = false;
        public List <ProfileAddressJson> Addresses { get; set; } = new List<ProfileAddressJson>();


    }
}
