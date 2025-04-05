using FluentValidation;
using Models;
using Models.Profiles;
using Models.Profiles.interfaces;

namespace WebAPI.Validators
{
    public class ProfileAddressCreateValidator : AbstractValidator<ProfileAddressCreateModel>
    {

        public ProfileAddressCreateValidator()
        {
            Include(new AddressBaseValidator());

            RuleFor(field => field).Must(IsPrimaryOrSecondary).WithMessage("Select either a primary or a secondary address type.");

        }

        protected bool IsPrimaryOrSecondary(IProfileAddressCreateModel aAddress)
        {

            if (aAddress.IsPrimary == aAddress.IsSecondary)
            {
                return false;
            }

            return true;
        }
    }
}
