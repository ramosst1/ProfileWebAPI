using FluentValidation;
using Models.Profiles;

namespace WebAPI.Validators
{
    public class ProfileModelBaseValidator : AbstractValidator<ProfileModelBase>
    {
        public ProfileModelBaseValidator()
        {

            RuleFor(field => field.FirstName).NotEmpty().WithMessage("{PropertyName} is required.")
                .Length(2, 50).WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters.");
            RuleFor(field => field.LastName).NotEmpty().WithMessage("{PropertyName} is required.")
                .Length(2, 50).WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters.");

        }
    }
}
