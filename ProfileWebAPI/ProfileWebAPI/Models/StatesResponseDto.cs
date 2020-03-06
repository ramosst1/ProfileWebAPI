using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileWebAPI.Models
{
    public class StatesResponseDto : APIResponseDto, IStatesResponse
    {

        public List <IState> States { get; set; } = new List <IState>();

    }
}
