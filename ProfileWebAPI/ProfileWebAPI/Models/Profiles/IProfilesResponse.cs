using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileWebAPI.Models.Profiles
{
    public interface IProfilesResponse: IAPIResponse
    {
        List <IProfile> Profiles { get; set; }

    }
}
