using Microsoft.AspNetCore.Mvc;
using Models.APIResponses.Profiles;
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
        public async Task<ActionResult<ProfilesResponse>> ProfilesAsync()
        {

            var response = await _profileService.GetProfilesAsync();

            return response;
        }

        // GET api/v1/profiles/5
        [HttpGet("{profileId}")]
        public async Task<ActionResult<ProfileResponse>> GetAsync(int profileId)
        {
            var response = await _profileService.GetProfileByIdAsync(profileId);

            return response;
        }

        // POST api/v1/profiles
        [HttpPost]
        public async Task<ActionResult<ProfileResponse>> PostAsync([FromBody] ProfileCreateModel profile)
        {
            var response = await _profileService.CreateProfileAsync(profile);

            return response;
        }

        // PUT api/v1/profile/Profile
        [HttpPut]
        public async Task<ActionResult<ProfileResponse>> PutAsync(ProfileUpdateModel profile)
        {
            var response = await _profileService.UpdateProfileAsync(profile);

            return response;
        }

        // Delete api/v1/profiles/5
        [HttpDelete("{profileId}")]
        public async Task<ActionResult<ApiResponse>> DeleteAsync(int profileId)
        {
            var response = await _profileService.DeleteProfilesAsync(profileId);

            return response;
        }

    }
}
