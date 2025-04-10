using FluentValidation;

namespace Models.Profiles.Validators
{

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
