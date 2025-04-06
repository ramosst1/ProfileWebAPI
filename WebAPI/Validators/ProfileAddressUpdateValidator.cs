using FluentValidation;
using Models.Profiles;

namespace WebAPI.Validators
{
    public class ProfileAddressUpdateValidator : AbstractValidator<ProfileAddressUpdateModel>
    {

        public ProfileAddressUpdateValidator()
        {
            Include(new AddressModelBaseValidator());

            RuleFor(field => field.ProfileId).Must(x => x > 0).WithMessage("{PropertyName} is not a proper id.");
            RuleFor(field => field.AddressId).Must(x => x > 0).WithMessage("{PropertyName} is not a proper id.");
            RuleFor(field => field).Must(IsPrimaryOrSecondary).WithMessage("Select either a primary or a secondary address type.");

        }

        protected bool IsPrimaryOrSecondary(ProfileAddressUpdateModel aAddress)
        {

            if (aAddress.IsPrimary == aAddress.IsSecondary)
            {
                return false;
            }

            return true;
        }
    }
}
