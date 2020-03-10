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
        public ActionResult <List <IState>>  Get()
        {
            try
            {

                return _StateManager.GetAllStates();

            }
            catch (Exception ex) {

                var ErrorList = new List<ErrorMessageDto>();

                ErrorList.Add(new ErrorMessageDto()
                {
                    StatusCode = "500",
                     Message = "An unexpected error occured"
                });

                return BadRequest( ErrorList);
            }

        }

    }
}
