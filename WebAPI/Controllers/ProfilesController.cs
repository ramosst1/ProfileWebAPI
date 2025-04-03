using Microsoft.AspNetCore.Mvc;
using Models.Profiles;
using Profiles;
using Profiles.Models.APIResponses;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfilesController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        // GET api/v1/profiles
        [HttpGet()]
        public async Task<ActionResult> ProfilesAsync()
        {

            var response = await _profileService.GetProfilesAsync();

            if(response.Success)
                return Ok(response.data);

            return BadRequest(response.Messages);
        }

        // GET api/v1/profiles/5
        [HttpGet("{profileId}")]
        public async Task<ActionResult> GetAsync(int profileId)
        {
            var response = await _profileService.GetProfileByIdAsync(profileId);

            if (response.Success)
                return Ok(response.data);

            return BadRequest(response.Messages);
        }

        // POST api/v1/profiles
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] ProfileCreateModel profile)
        {
            var response = await _profileService.CreateProfileAsync(profile);

            if (response.Success)
                return Ok(response.data);

            return BadRequest(response.Messages);
        }

        // PUT api/v1/profile/Profile
        [HttpPut]
        public async Task<ActionResult> PutAsync(ProfileUpdateModel profile)
        {
            var response = await _profileService.UpdateProfileAsync(profile);

            if (response.Success)
                return Ok(response.data);

            return Ok(response);
        }

        // Delete api/v1/profiles/5
        [HttpDelete("{profileId}")]
        public async Task<ActionResult<ApiResponse>> DeleteAsync(int profileId)
        {
            var response = await _profileService.DeleteProfilesAsync(profileId);

            if (response.Success)
                return Ok(response);

            return BadRequest(response.Messages);
        }

    }
}



