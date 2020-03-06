using System;
using System.Collections.Generic;
using System.Text;

namespace Profiles.Models.APIResponses
{
    public abstract class ResponseBase : IResponseBase
    {
        public bool Success { get; set; }
        public List<IErrorMessage> Messages { get; set; } = new List<IErrorMessage>();


    }
}
