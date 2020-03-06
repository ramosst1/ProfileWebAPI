using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileWebAPI.Models
{
    public class StateDto : IState
    {
        public string StateName { get; set; }
        public string StateAbrev { get; set; }

    }
}
