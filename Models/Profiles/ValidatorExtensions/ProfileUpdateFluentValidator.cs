using FluentValidation;
using Models.Common.ValidationResponses;
using Models.Common.ValidationResponses.Converters;

namespace Models.Profiles.ValidatorExtensions
{

    public static class ProfileUpdateValidatorExtentions  {

        public static ValidationResponse Validate(this ProfileUpdateModel profileUpdateModel)
        {

            var response = new ValidationResponse();

            response.Messages.AddRange(((ProfileModelBase)profileUpdateModel).Validate().Messages);

            var validationResponse = new ProfileUpdateFluentValidator().Validate(profileUpdateModel);

            response.Messages.AddRange(FluentValidationConverter.ConvertToValidationErrors(validationResponse.Errors));

            response.Messages.AddRange(profileUpdateModel.Addresses.Validate().Messages);

            return response;
        }

        public class ProfileUpdateFluentValidator : AbstractValidator<ProfileUpdateModel>
        {
            public ProfileUpdateFluentValidator()
            {
                RuleFor(field => field.ProfileId).Must(x => x > 0).WithMessage("{PropertyName} is not a valid id.");
            }
        }
    }
}
