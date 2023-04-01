using Microsoft.AspNetCore.Mvc;
using Models.APIResponses.States;
using Services.States;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IStatesServices _statesServices;

        public StatesController(IStatesServices statesServices)
        {
            _statesServices = statesServices;
        }

        [HttpGet]
        public async Task<ActionResult<StatesResponse>> Get()
        {

            return await _statesServices.GetAllStatesAsync();
        }
     }
 }
