using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfileWebAPI.Models.Profiles;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using Profiles;
using ProfileWebAPI.ProfilesProcessors;

namespace ProfileWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private IProfileManager _ProfileManager { get; }

        public ProfilesController(IProfileManager profileManager)
        {
            _ProfileManager = profileManager;

        }

        // GET api/v1/profiles
        [HttpGet()]
        public ActionResult<List <IProfile>> Get()
        {

            IProfilesResponse Response;

            var ProfilesResponses = _ProfileManager.GetProfiles();

            if (ProfilesResponses.Success == false) {
                return BadRequest(ProfilesResponses.Messages);
            }


            Response = Util.ProfileConverter.Convert(ProfilesResponses);


            return Response.Profiles;


        }

        // GET api/v1/profiles/5
        [HttpGet("{profileId}")]
        public ActionResult<IProfile> Get(int profileId)
        {

            IProfileResponse AProfileResponse ;

            var AProfile = _ProfileManager.GetProfileById(profileId);

            AProfileResponse = Util.ProfileConverter.Convert(AProfile);

            if (AProfileResponse.Success == false) {

                return BadRequest(AProfileResponse.ErrorMessages);
            }

            return (ProfileDto) AProfileResponse.Profile;

        }

        // POST api/v1/profiles
        [HttpPost]
        public ActionResult <IProfile> Post([FromBody] ProfileDto profile)
        {
            IProfileProcessorManager ProfileProcessorMgr = new ProfilesProcessors.ProfileProcessorManager(_ProfileManager);

            var ProcessorMgrResults = ProfileProcessorMgr.UpdateProfile(profile);

            if (ProcessorMgrResults.Success == false) {
                return BadRequest(ProcessorMgrResults.ErrorMessages);
            }

            return (ProfileDto) ProcessorMgrResults.Profile;
        }

        // PUT api/v1/profile/CreateProfile
        [HttpPut]
        public ActionResult<IProfile> Put(ProfileNew aProfile)
        {


            IProfileProcessorManager ProfileProcessorMgr = new ProfilesProcessors.ProfileProcessorManager(_ProfileManager);

            var AProfileProcessResults =  ProfileProcessorMgr.CreateProfile(aProfile);

            if (AProfileProcessResults.Success == false) {
                return BadRequest(AProfileProcessResults.ErrorMessages);
            }

            return (ProfileDto) AProfileProcessResults.Profile;
        }

        // Delete api/v1/profile/DeleteProfile
        [HttpDelete("{profileId}")]
        public ActionResult<bool> Delete(int  profileId ) {

            IProfileResponse AProfileResponse;

            var DeletedResponse = _ProfileManager.DeleteProfiles(profileId);

            AProfileResponse = Util.ProfileConverter.Convert(DeletedResponse);

            if (AProfileResponse.Success == false) {
                return BadRequest(AProfileResponse.ErrorMessages);
            }
 
            return true;

        }

    }
}