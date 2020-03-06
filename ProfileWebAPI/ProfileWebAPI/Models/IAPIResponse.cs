using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileWebAPI.Models
{
    public interface IAPIResponse
    {

        bool Success { get; set; }
        List <IErrorMessage> ErrorMessages { get; set; }
    }
}
