using FluentValidation;
using Models.Common.ValidationResponses;

namespace Models.Profiles.ValidatorExtensions
{

    public static class ProfileModelBaseValidatorExtension {

        public static ValidationResponse Validate(this ProfileModelBase profileUpdateModel)
        {

            var response = new ValidationResponse();

            var validationResponse = new ProfileModelBaseFluentValidator().Validate(profileUpdateModel);

            response.Messages.AddRange(FluentValidationConverter.ConvertToValidationErrors(validationResponse.Errors));

            return response;
        }

        public class ProfileModelBaseFluentValidator : AbstractValidator<ProfileModelBase>
        {
            public ProfileModelBaseFluentValidator()
            {

                RuleFor(field => field.FirstName).NotEmpty().WithMessage("{PropertyName} is required.")
                    .Length(2, 50).WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters.");
                RuleFor(field => field.LastName).NotEmpty().WithMessage("{PropertyName} is required.")
                    .Length(2, 50).WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters.");

            }
        }

    }


}
