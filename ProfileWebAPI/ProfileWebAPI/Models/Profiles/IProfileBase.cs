using System.Collections.Generic;

namespace ProfileWebAPI.Models.Profiles
{
    public interface IProfileBase
    {
        bool Active { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}