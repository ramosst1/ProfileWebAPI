using FluentValidation;
using Models.Common.Addresses;
using Models.Common.Addresses.ValidatorsExtensions;
using Models.Common.ValidationResponses;
using static Models.Profiles.ValidatorExtensions.ProfileAddressUpdateValidatorExtension;

namespace Models.Profiles.ValidatorExtensions
{

    public static class ProfileAddressCreateValidatorExtension {

        public static ValidationResponse Validate(this List<ProfileAddressCreateModel> profileAddressCreateModes) {

            var response = new ValidationResponse();

            foreach (var profileAddressCreateModel in profileAddressCreateModes)
            {
                response.Messages.AddRange(profileAddressCreateModel.Validate().Messages);
            }

            return response;
        }

        public static ValidationResponse Validate(this ProfileAddressCreateModel profileCreateModel) {

            var response = new ValidationResponse();

            response.Messages.AddRange(((AddressModelBase)profileCreateModel).Validate().Messages);

            var validationResponse = new ProfileAddressCreateFluentValidator().Validate(profileCreateModel);

            response.Messages.AddRange(FluentValidationConverter.ConvertToValidationErrors(validationResponse.Errors));

            return response;

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
