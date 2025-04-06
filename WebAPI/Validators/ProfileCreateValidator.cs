using FluentValidation;
using Models.Profiles;

namespace WebAPI.Validators
{
    public class ProfileCreateValidator : AbstractValidator<ProfileCreateModel>
    {
        public ProfileCreateValidator()
        {
            Include(new ProfileModelBaseValidator());
            RuleForEach(x => x.Addresses).SetValidator(new ProfileAddressCreateValidator());
        }
    }
}
