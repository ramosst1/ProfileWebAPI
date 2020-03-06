using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileWebAPI.Models
{
    public abstract class APIResponseDto:  IAPIResponse
    {
        public bool Success { get; set; } = false;
        public List<IErrorMessage> ErrorMessages { get ; set; }
    }
}
