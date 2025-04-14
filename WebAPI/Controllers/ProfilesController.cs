using Microsoft.AspNetCore.Mvc;
using Models.Common.APIResponses;
using Models.Common.ValidationResponses;
using Models.Profiles;
using Models.Profiles.ValidatorExtensions;
using Services.Profiles.Interfaces;

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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ApiResponse<List<ProfileModel>>), StatusCodes.Status200OK)]
        public async Task<ActionResult> ProfilesAsync()
        {

            var response = await _profileService.GetProfilesAsync();

            return Ok(response);

        }

        // GET api/v1/profiles/5
        [HttpGet("{profileId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ApiResponse<ProfileModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAsync(int profileId)
        {
            var response = await _profileService.GetProfileByIdAsync(profileId);

            return Ok(response);
        }

        // POST api/v1/profiles
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(List<ValidationErrorMessage>),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProfileModel), StatusCodes.Status200OK)]
        public async Task<ActionResult> PostAsync([FromBody] ProfileCreateModel profile)
        {

            var validation = profile.Validate();
            if (!validation.IsValid) return BadRequest(validation.Messages);

            var response = await _profileService.CreateProfileAsync(profile);

            return Ok(response);
        }

        // PUT api/v1/profile/Profile
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(List<ValidationErrorMessage>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProfileModel), StatusCodes.Status200OK)]
        public async Task<ActionResult> PutAsync(ProfileUpdateModel profile)
        {

            var validation = profile.Validate();
            if (!validation.IsValid) return BadRequest(validation.Messages);

            var response = await _profileService.UpdateProfileAsync(profile);

            return Ok(response);
        }

        // Delete api/v1/profiles/5
        [HttpDelete("{profileId}")]
        public async Task<ActionResult<ApiResponse>> DeleteAsync(int profileId)
        {
            var response = await _profileService.DeleteProfilesAsync(profileId);

            return Ok(response);

        }

    }
}



