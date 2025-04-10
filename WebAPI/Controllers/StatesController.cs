using Microsoft.AspNetCore.Mvc;
using Models.States;
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(List<StateModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get()
        {

            var response = await _statesServices.GetAllStatesAsync();

            if (response.Success)
                return Ok(response.data);

            return BadRequest(response.ErrorMessages);
        }
     }
 }
