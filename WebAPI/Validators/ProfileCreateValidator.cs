using FluentValidation;
using Models.Profiles;

namespace WebAPI.Validators
{
    public class ProfileCreateValidator : AbstractValidator<ProfileCreateModel>
    {
        public ProfileCreateValidator()
        {
            Include(new ProfileBaseValidator());
         //   RuleFor(x => x.Addresses.Count).GreaterThan(0).WithMessage("An Address is required.");
            RuleForEach(x => x.Addresses).SetValidator(new ProfileAddressCreateValidator());
        }
    }
}
