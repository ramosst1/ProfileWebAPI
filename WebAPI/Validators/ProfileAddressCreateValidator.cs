using FluentValidation;
using Models;
using Models.Profiles;

namespace WebAPI.Validators
{
    public class ProfileAddressCreateValidator : AbstractValidator<ProfileAddressCreateModel>
    {

        public ProfileAddressCreateValidator()
        {
            Include(new AddressBaseValidator());

            RuleFor(field => field).Must(IsPrimaryOrSecondary).WithMessage("Select either a primary or a secondary address type.");

        }

        protected bool IsPrimaryOrSecondary(ProfileAddressCreateModel aAddress)
        {

            if (aAddress.IsPrimary == aAddress.IsSecondary)
            {
                return false;
            }

            return true;
        }
    }
}
