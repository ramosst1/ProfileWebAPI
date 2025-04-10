using FluentValidation;
using Models.APIResponses;
using Models.Common.Addresses;
using Models.Common.Addresses.Validators;

namespace Models.Profiles.Validators
{
    public static class ProfileAddressUpdateValidator
    {
        public static List<ValidationErrorMessage> Validate(this List<ProfileAddressUpdateModel> profileAddressUpdateModes)
        {

            var results = new List<ValidationErrorMessage>();

            foreach (var profileAddressUpdateModel in profileAddressUpdateModes)
            {
                results.AddRange(Validate(profileAddressUpdateModel));
            }

            return results;
        }

        public static List<ValidationErrorMessage> Validate(this ProfileAddressUpdateModel profileAddressUpdateModel)
        {

            var results = ((AddressModelBase) profileAddressUpdateModel).Validate();


            results.AddRange(new ProfileAddressUpdateFluentValidator().Validate(profileAddressUpdateModel)
                .Errors.Select(error => {
                    return new ValidationErrorMessage()
                    {
                        Message = error.ErrorMessage,
                        StatusCode = "400"
                    };
                 })
             );

            return results;
        }
    }

    public class ProfileAddressUpdateFluentValidator : AbstractValidator<ProfileAddressUpdateModel>
    {

        public ProfileAddressUpdateFluentValidator()
        {
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
