using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileWebAPI.Models.Profiles
{
    public interface IProfileResponse: IAPIResponse
    {
        IProfile Profile { get; set; }
    }
}
