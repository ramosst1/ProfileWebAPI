using FluentValidation;
using Models.Profiles;

namespace WebAPI.Validators
{
    public class ProfileAddressValidator : AbstractValidator<ProfileAddressModel>
    {

        public ProfileAddressValidator()
        {

            Include(new AddressBaseValidator());
            RuleFor(field => field.ProfileId).Must(x => x > 0).WithMessage("{PropertyName} is not a valid id.");

            RuleFor(field => field.AddressId).Must(x => x > 0).WithMessage("{PropertyName} is not a proper address id.");

            RuleFor(field => field).Must(IsPrimaryOrSecondary).WithMessage("Select either a primary or a secondary address type");

        }

        protected bool IsPrimaryOrSecondary(ProfileAddressModel aAddress)
        {

            if (aAddress.IsPrimary == aAddress.IsSecondary)
            {
                return false;
            }

            return true;
        }

    }
}
