using Models.APIResponses;
using Models.APIResponses.interfaces;
using Models.Profiles;
using Models.Profiles.interfaces;
using Profiles;
using Profiles.Models.APIResponses;
using Repositories.Models.Profiles;
using Repositories.Profiles;
using Utilities.Converters.ObjectConverter;

namespace Services.Profiles
{
    public class ProfileService : IProfileService
    {

        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }
        public async Task<IApiResponse<List<IProfileModel>>> GetProfilesAsync()
        {

            IApiResponse<List<IProfileModel>> response = new ApiResponse<List<IProfileModel>>();

            try
            {
                var profiles = await _profileRepository.GetProfilesAsync();

                response.data = Convert<List<ProfileDto>, List<IProfileModel>>(profiles);

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

        public async Task<IApiResponse<IProfileModel>> GetProfileByIdAsync(int profileId)
        {

            IApiResponse<IProfileModel> response = new ApiResponse<IProfileModel>();

            try
            {

                var profile = await _profileRepository.GetProfileByIdAsync(profileId);

                if (profile == null)
                {
                    response.Success = false;
                }
                else {
                    response.data = Convert<ProfileDto, IProfileModel>(profile);

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

        public async Task<IApiResponse<IProfileModel>> CreateProfileAsync(IProfileCreateModel aProfile)
        {
            IApiResponse<IProfileModel> response = new ApiResponse<IProfileModel>();
            try
            {
                var newProfile = Convert<IProfileCreateModel, ProfileCreateDto>(aProfile);

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

                    response.data = Convert<ProfileDto, ProfileModel>(newProfileCreated);

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

        public async Task<IApiResponse<IProfileModel>> UpdateProfileAsync(IProfileUpdateModel aProfile)
        {

            IApiResponse<IProfileModel> response = new ApiResponse<IProfileModel>();
            try
            {
                var newProfile = Convert<IProfileUpdateModel, ProfileUpdateDto>(aProfile);

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

                    response.data = Convert<ProfileDto, ProfileModel>(updatedProfileCreated);

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

        public async Task<IApiResponse> DeleteProfilesAsync(int profileId)
        {
            IApiResponse response = new ApiResponse();

            try
            {
                var result = await _profileRepository.DeleteProfileAsync(profileId);
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

        private static TTarget Convert<TSource, TTarget>(TSource source)
        {
            var response = DataMapperConverter.Convert<TSource, TTarget>(source);

            return response;
        }
    }
}
