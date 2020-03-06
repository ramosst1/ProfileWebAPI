using Profiles.Models.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profiles.Models.APIResponses
{
    public interface IAddressesResponse: IResponseBase
    {
        List <IProfileAddress>  Addresses { get; set; }

    }
}
