using Models.Common.APIResponses;
using Models.Profiles;
using Repositories.Models.Profiles;
using Repositories.Profiles.Interfaces;
using Services.Profiles.DataMapperExtensions;
using Services.Profiles.Interfaces;

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
                List<ProfileDto> profiles = await _profileRepository.GetProfilesAsync();

                response.data = profiles.MapDataAsProfileModel();

                response.Success = true;
            }
            catch (Exception ex) {
                return ErrorResponse<List<ProfileModel>> (ex);
            }

            return response;
        }

        public async Task<ApiResponse<ProfileModel>> GetProfileByIdAsync(int profileId)
        {

            var response = new ApiResponse<ProfileModel>();

            try
            {

                ProfileDto profile = await _profileRepository.GetProfileByIdAsync(profileId);

                if (profile == null)
                {
                    response.Success = false;
                }
                else {
                    response.data = profile.MapDataAsProfileModel();

                    response.Success = true;
                }

            }
            catch (Exception ex)
            {
                return ErrorResponse<ProfileModel>(ex);
            }

            return response;
        }

        public async Task<ApiResponse<ProfileModel>> CreateProfileAsync(ProfileCreateModel aProfile)
        {
            var response = new ApiResponse<ProfileModel>();
            try
            {
                ProfileCreateDto newProfile = aProfile.MapDataAsProfileCreateDto();

                var newProfileCreated = await _profileRepository.CreateProfileAsync(newProfile);

                if (newProfileCreated == null) 
                    return ErrorResponse<ProfileModel>("Unable to create the profile", "Unable to create the profile");

                response.data = newProfileCreated.MapDataAsProfileModel();

                response.Success = true;
            }
            catch (Exception ex)
            {
                return ErrorResponse<ProfileModel>(ex);
            }

            return response;
        }

        public async Task<ApiResponse<ProfileModel>> UpdateProfileAsync(ProfileUpdateModel aProfileModel)
        {

            var response = new ApiResponse<ProfileModel>();

            try
            {
                ProfileUpdateDto profileToUpdate = aProfileModel.MapDataAsProfileUpdateDto();

                var updatedProfileDto = await _profileRepository.UpdateProfileAsync(profileToUpdate);

                if (updatedProfileDto == null) 
                    return ErrorResponse<ProfileModel>("Unable to update the profile", "Unable to update the profile");

                response.data = updatedProfileDto.MapDataAsProfileModel();

                response.Success = true;
            }
            catch (Exception ex)
            {
                return ErrorResponse<ProfileModel>(ex);
            }

            return response;
        }

        public async Task<ApiResponse> DeleteProfilesAsync(int profileId)
        {
            var response = new ApiResponse();

            try
            {
                bool result = await _profileRepository.DeleteProfileAsync(profileId);

                response.Success = result;

                if (!result) {
                    return ErrorResponse("Unable to delete the profile", "Unable to delete the profile");
                }

            }

            catch (Exception ex)
            {

                response.Success = false;
                response.ErrorMessages.Add(new ErrorMessageModel()
                {
                    ExternalMessage = ex.Message,
                    InternalMessage = ex.Message // Can be used for logging the error for troublshooting
                });
            }

            return response;
        }

        private static ApiResponse<TResponse> ErrorResponse<TResponse>(Exception ex)
        {

            var response = new ApiResponse<TResponse>();

            response.Success = false;
            response.ErrorMessages.Add(new ErrorMessageModel()
            {
                ExternalMessage = ex.Message,
                InternalMessage = ex.Message // Can be used for logging the error for troublshooting
            });

            return response;
        }

        private static ApiResponse<TResponse> ErrorResponse<TResponse>(string internalMessage, string externalMessage)
        {

            var response = new ApiResponse<TResponse>();

            response.Success = false;
            response.ErrorMessages.Add(new ErrorMessageModel()
            {
                ExternalMessage = externalMessage,
                InternalMessage = internalMessage // Can be used for logging the error for troublshooting
            });

            return response;
        }

        private static ApiResponse ErrorResponse(string internalMessage, string externalMessage)
        {

            var response = new ApiResponse();

            response.Success = false;
            response.ErrorMessages.Add(new ErrorMessageModel()
            {
                ExternalMessage = externalMessage,
                InternalMessage = internalMessage // Can be used for logging the error for troublshooting
            });

            return response;
        }
    }
}

