using FluentValidation;
using Models.Common.Addresses;
using Models.Common.Addresses.ValidatorsExtensions;
using Models.Common.ValidationResponses;
using Models.Common.ValidationResponses.Converters;

namespace Models.Profiles.ValidatorExtensions
{
    public static class ProfileAddressUpdateValidatorExtension
    {
        public static ValidationResponse Validate(this List<ProfileAddressUpdateModel> profileAddressUpdateModes)
        {

            var response = new ValidationResponse();

            foreach (var profileAddressUpdateModel in profileAddressUpdateModes)
            {
                response.Messages.AddRange(profileAddressUpdateModel.Validate().Messages);
            }

            return response;
        }

        public static ValidationResponse Validate(this ProfileAddressUpdateModel profileAddressUpdateModel)
        {

            var response = new ValidationResponse();

            response.Messages.AddRange(((AddressModelBase)profileAddressUpdateModel).Validate().Messages);

            var validationResponse = new ProfileAddressUpdateFluentValidator().Validate(profileAddressUpdateModel);

            response.Messages.AddRange(FluentValidationConverter.ConvertToValidationErrors(validationResponse.Errors));

            return response;
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
}