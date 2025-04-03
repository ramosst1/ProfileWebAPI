using Models.APIResponses;
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
        public async Task<ApiResponse<List<ProfileModel>>> GetProfilesAsync()
        {

            var response = new ApiResponse<List<ProfileModel>>();

            try
            {

                var profiles = await _profileRepository.GetProfilesAsync();

                response.data = ProfileConverter.Convert(profiles);
                response.Success = true;
            }
            catch (Exception ex) {

                response.Success = false;
                response.Messages.Add(new ErrorMessageModel()
                {
                    ExternalMessage = ex.Message,
                    InternalMessage = ex.Message // Can be used for logging the error for troublshooting
                });

            }

            return response;
        }

        public async Task<ApiResponse<ProfileModel>> GetProfileByIdAsync(int profileId)
        {

            var response = new ApiResponse<ProfileModel>();

            try
            {

                var profile = await _profileRepository.GetProfileByIdAsync(profileId);

                if (profile == null)
                {
                    response.Success = false;
                }
                else {
                    response.data = ProfileConverter.Convert(profile);
                    response.Success = true;
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Messages.Add(new ErrorMessageModel()
                {
                    ExternalMessage = ex.Message,
                    InternalMessage = ex.Message // Can be used for logging the error for troublshooting
                });
            }

            return response;
        }

        public async Task<ApiResponse<ProfileModel>> CreateProfileAsync(ProfileCreateModel aProfile)
        {
            var response = new ApiResponse<ProfileModel>();
            try
            {
                var newProfile = Util.ProfileConverter.ConvertToNewDto(aProfile);

                var newProfileCreated = await _profileRepository.CreateProfileAsync(newProfile);

                if (newProfileCreated == null)
                {
                    response.Success = false;
                    response.Messages.Add(new ErrorMessageModel()
                    {
                        ExternalMessage = "Unable to create the profile",
                        InternalMessage = "Unable to create the profile"
                    });
                }
                else
                {
                    response.data = Util.ProfileConverter.Convert(newProfileCreated);
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Messages.Add(new ErrorMessageModel()
                {
                    ExternalMessage = ex.Message,
                    InternalMessage = ex.Message // Can be used for logging the error for troublshooting
                });

            }

            return response;
        }

        public async Task<ApiResponse<ProfileModel>> UpdateProfileAsync(ProfileUpdateModel aProfile)
        {

            var response = new ApiResponse<ProfileModel>();
            try
            {
                var newProfile = Util.ProfileConverter.ConvertToUpdateDto(aProfile);

                var updatedProfileCreated = await _profileRepository.UpdateProfileAsync(newProfile);

                if (updatedProfileCreated == null)
                {
                    response.Success = false;
                    response.Messages.Add(new ErrorMessageModel()
                    {
                        ExternalMessage = "Unable to update the profile",
                        InternalMessage = "Unable to update the profile"
                    });
                }
                else {
                    response.data = (Util.ProfileConverter.Convert(updatedProfileCreated));
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Messages.Add(new ErrorMessageModel()
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
                    response.Messages.Add(new ErrorMessageModel()
                    {
                        ExternalMessage = "Unable to delete the profile",
                        InternalMessage = "Unable to delete the profile"
                    });
                }

            }

            catch (Exception ex)
            {

                response.Success = false;
                response.Messages.Add(new ErrorMessageModel()
                {
                    ExternalMessage = ex.Message,
                    InternalMessage = ex.Message // Can be used for logging the error for troublshooting
                });
            }

            return response;
        }
    }
}
