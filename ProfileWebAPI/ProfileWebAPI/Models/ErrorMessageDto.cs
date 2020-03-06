using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileWebAPI.Models
{
    public class ErrorMessageDto : IErrorMessage
    {

        public string Message { get; set; } = "";

        public string FieldName { get; set; } = "";

        public string StatusCode { get; set; } = "";

    }
}
