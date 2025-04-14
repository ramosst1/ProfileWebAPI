using Models.Common.ValidationResponses;

namespace Models.Profiles.ValidatorExtensions
{

    public static class ProfileCreateValidatorExtension {

        public static ValidationResponse Validate(this ProfileCreateModel profileCreateModel)
        {

            var response = new ValidationResponse();

            response.Messages.AddRange(((ProfileModelBase)profileCreateModel).Validate().Messages);

            response.Messages.AddRange(profileCreateModel.Addresses.Validate().Messages);
            return response;
        }
    }

}
