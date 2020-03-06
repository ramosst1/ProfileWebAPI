using Newtonsoft.Json;
using ProfileWebAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileWebAPI.States
{
    public class StateManagerJson : IStateManager
    {
        public List<IState> GetAllStates()
        {

            return GetStatesJson();
        }

        private List<IState> GetStatesJson()
        {

            List<IState> StatesList = new List<IState>();

            using (StreamReader r = new StreamReader(@"JsonData/States.json"))
            {
                string json = r.ReadToEnd();

                var States = JsonConvert.DeserializeObject<List<StateDto>>(json);

                return  States.Cast<IState>().ToList();


            }

        }

    }
}
