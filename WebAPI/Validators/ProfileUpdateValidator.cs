using FluentValidation;
using Models.Profiles;

namespace WebAPI.Validators
{
    public class ProfileUpdateValidator : AbstractValidator<ProfileUpdateModel>
    {
        public ProfileUpdateValidator()
        {
            Include(new ProfileModelBaseValidator());

            RuleFor(field => field.ProfileId).Must(x => x > 0).WithMessage("{PropertyName} is not a valid id.");
            RuleForEach(x => x.Addresses).SetValidator(new ProfileAddressUpdateValidator());

        }
    }
}
