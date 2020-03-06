using System;
using System.Collections.Generic;
using System.Text;

namespace Profiles.Models.APIResponses
{
    public class ErrorMessage : IErrorMessage
    {
        public string InternalMessage { get; set; }
        public string ExternalMessage { get; set; }
        public string StatusCode { get; set; }
    }
}
