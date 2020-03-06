using System.Collections.Generic;
using Profiles.Models.Profiles;

namespace Profiles.Models.ProfileJson
{
    public interface IProfileJson
    {
        int ProfileId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        bool Active { get; set; }
        List<ProfileAddressJson> Addresses { get; set; }
        bool IsPrimary { get; set; }
    }
}