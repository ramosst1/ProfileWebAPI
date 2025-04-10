using FluentValidation;
using Models.APIResponses;
using Models.Common.Addresses.Validators;

namespace Models.Profiles.Validators
{

    public static class ProfileAddressCreateValidator {

        public static List<ValidationErrorMessage> Validate(this List<ProfileAddressCreateModel> profileAddressCreateModes) {

            var results = new List<ValidationErrorMessage>();

            foreach (var profileAddressCreateModel in profileAddressCreateModes) {
                results.AddRange(profileAddressCreateModel.Validate());
            }

            return results;
        }

        public static List<ValidationErrorMessage> Validate(this ProfileAddressCreateModel profileCreateModel) {

            var results = new ProfileAddressCreateFluentValidator().Validate(profileCreateModel);

            return results.Errors.Select(error => {
                return new ValidationErrorMessage() { 
                    Message = error.ErrorMessage, 
                     StatusCode = "400"
                };
            }).ToList();
        } 
    }

    public class ProfileAddressCreateFluentValidator: AbstractValidator<ProfileAddressCreateModel>
    {

        public ProfileAddressCreateFluentValidator()
        {
            Include(new AddressModelBaseFluentValidator());

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
