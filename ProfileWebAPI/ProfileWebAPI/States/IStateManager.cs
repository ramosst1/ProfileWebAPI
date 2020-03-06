using System.Collections.Generic;
using ProfileWebAPI.Models;

namespace ProfileWebAPI.States
{
    public interface IStateManager
    {
        List<IState> GetAllStates();
    }
}