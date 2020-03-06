using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProfileWebAPI.Models;
using ProfileWebAPI.States;

namespace ProfileWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {

        private IStateManager _StateManager { get; }

        public StatesController(IStateManager statesManager)
        {
            _StateManager = statesManager;
        }

        // GET: api/States
        [HttpGet] 
        public ActionResult<StatesResponseDto>  Get()
        {
            IStatesResponse AResponse = new StatesResponseDto();

            AResponse.States = _StateManager.GetAllStates();
            AResponse.Success = true;

            return (StatesResponseDto)AResponse;

        }

    }
}
