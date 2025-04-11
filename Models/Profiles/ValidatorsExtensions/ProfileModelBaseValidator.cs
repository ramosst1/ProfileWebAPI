using FluentValidation;
using Models.APIResponses;

namespace Models.Profiles.ValidatorsExtensions
{

    public static class ProfileModelBaseValidator {

        public static List<ValidationErrorMessage> Validate(this ProfileModelBase profileUpdateModel)
        {

            var results = new ProfileModelBaseFluentValidator().Validate(profileUpdateModel)
                .Errors.Select(error =>
                {
                    return new ValidationErrorMessage()
                    {
                        Message = error.ErrorMessage,
                        StatusCode = "400"
                    };
                }
             ).ToList();

            return results;
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
