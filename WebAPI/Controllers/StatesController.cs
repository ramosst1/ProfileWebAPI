using Microsoft.AspNetCore.Mvc;
using Services.States.Interfaces;

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
        public async Task<ActionResult> Get()
        {

            var response = await _statesServices.GetAllStatesAsync();

            if (response.Success)
                return Ok(response.data);

            return BadRequest(response.Messages);
        }
     }
 }
