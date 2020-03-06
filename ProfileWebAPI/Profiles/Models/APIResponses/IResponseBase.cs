using System.Collections.Generic;

namespace Profiles.Models.APIResponses
{
    public interface IResponseBase
    {
        bool Success { get; set; }

        List<IErrorMessage> Messages { get; set; }
    }
}