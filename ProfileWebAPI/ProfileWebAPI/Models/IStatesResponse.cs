using System.Collections.Generic;

namespace ProfileWebAPI.Models
{
    public interface IStatesResponse: IAPIResponse
    {
        List <IState> States { get; set; }
    }
}