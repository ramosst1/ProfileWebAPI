using Profiles.Models.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profiles.Models.APIResponses
{
    public interface IProfilesResponse: IResponseBase
    {
        List<IProfile> Profiles { get; set; }

    }
}
