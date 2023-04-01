using Models.APIResponses;
using Models.APIResponses.Profiles;
using Models.Profiles;
using Profiles;
using Profiles.Models.APIResponses;
using Repositories.Profiles;
using Services.Util;

namespace Services.Profiles
{
    public class ProfileService : IProfileService
    {

        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }
        public async Task<ProfilesResponse> GetProfilesAsync()
        {

            var response = new ProfilesResponse();

            try
            {

                var profiles = await _profileRepository.GetProfilesAsync();

                response.Profiles = ProfileConverter.Convert(profiles);
                response.Success = true;
            }
            catch (Exception ex) {

                response.Success = false;
                response.Messages.Add(new ErrorMessage()
                {
                    ExternalMessage = ex.Message,
                    InternalMessage = ex.Message // Can be used for logging the error for troublshooting
                });

            }

            return response;
        }

        public async Task<ProfileResponse> GetProfileByIdAsync(int profileId)
        {

            var response = new ProfileResponse();

            try
            {

                var profile = await _profileRepository.GetProfileByIdAsync(profileId);

                if (profile == null)
                {
                    response.Success = false;
                }
                else {
                    response.Profile = ProfileConverter.Convert(profile);
                    response.Success = true;
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Messages.Add(new ErrorMessage()
                {
                    ExternalMessage = ex.Message,
                    InternalMessage = ex.Message // Can be used for logging the error for troublshooting
                });
            }

            return response;
        }

        public async Task<ProfileResponse> CreateProfileAsync(ProfileCreateModel aProfile)
        {
            var response = new ProfileResponse();
            try
            {
                var newProfile = Util.ProfileConverter.ConvertToNewDto(aProfile);

                var newProfileCreated = await _profileRepository.CreateProfileAsync(newProfile);

                if (newProfileCreated == null)
                {
                    response.Success = false;
                    response.Messages.Add(new ErrorMessage()
                    {
                        ExternalMessage = "Unable to create the profile",
                        InternalMessage = "Unable to create the profile"
                    });
                }
                else
                {
                    response.Profile = Util.ProfileConverter.Convert(newProfileCreated);
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Messages.Add(new ErrorMessage()
                {
                    ExternalMessage = ex.Message,
                    InternalMessage = ex.Message // Can be used for logging the error for troublshooting
                });

            }

            return response;
        }


        public async Task<ProfileResponse> UpdateProfileAsync(ProfileUpdateModel aProfile)
        {

            var response = new ProfileResponse();
            try
            {
                var newProfile = Util.ProfileConverter.ConvertToUpdateDto(aProfile);

                var updatedProfileCreated = await _profileRepository.UpdateProfileAsync(newProfile);

                if (updatedProfileCreated == null)
                {
                    response.Success = false;
                    response.Messages.Add(new ErrorMessage()
                    {
                        ExternalMessage = "Unable to update the profile",
                        InternalMessage = "Unable to update the profile"
                    });
                }
                else {
                    response.Profile = Util.ProfileConverter.Convert(updatedProfileCreated);
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Messages.Add(new ErrorMessage()
                {
                    ExternalMessage = ex.Message,
                    InternalMessage = ex.Message // Can be used for logging the error for troublshooting
                });

            }

            return response;
        }

        public async Task<ApiResponse> DeleteProfilesAsync(int profileId)
        {
            var response = new ApiResponse();

            try
            {
                var result = await  _profileRepository.DeleteProfileAsync(profileId);
                response.Success = result;

                if (!result) {
                    response.Messages.Add(new ErrorMessage()
                    {
                        ExternalMessage = "Unable to delete the profile",
                        InternalMessage = "Unable to delete the profile"
                    });
                }

            }

            catch (Exception ex)
            {

                response.Success = false;
                response.Messages.Add(new ErrorMessage()
                {
                    ExternalMessage = ex.Message,
                    InternalMessage = ex.Message // Can be used for logging the error for troublshooting
                });
            }

            return response;
        }
    }
}
