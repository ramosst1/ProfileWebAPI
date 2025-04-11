using FluentValidation;
using Models.APIResponses;
using Models.Common.Addresses;
using Models.Common.Addresses.ValidatorsExtensions;

namespace Models.Profiles.ValidatorExtensions
{

    public static class ProfileAddressCreateValidatorExtentions {

        public static List<ValidationErrorMessage> Validate(this List<ProfileAddressCreateModel> profileAddressCreateModes) {

            var results = new List<ValidationErrorMessage>();

            foreach (var profileAddressCreateModel in profileAddressCreateModes) {
                results.AddRange(profileAddressCreateModel.Validate());
            }

            return results;
        }

        public static List<ValidationErrorMessage> Validate(this ProfileAddressCreateModel profileCreateModel) {

            var results = ((AddressModelBase) profileCreateModel).Validate();

            results.AddRange(new ProfileAddressCreateFluentValidator().Validate(profileCreateModel)
                .Errors.Select(error =>
                {
                    return new ValidationErrorMessage()
                    {
                        Message = error.ErrorMessage,
                        StatusCode = "400"
                    };
                }
                )
             );

            return results;
        } 
 
        public class ProfileAddressCreateFluentValidator: AbstractValidator<ProfileAddressCreateModel>
        {

            public ProfileAddressCreateFluentValidator()
            {
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


}
