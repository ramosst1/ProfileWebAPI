using FluentValidation;
using Models.APIResponses;

namespace Models.Common.Addresses.Validators
{

    public static class AddressModelBaseValidator {

        public static List<ValidationErrorMessage> Validate(this List<AddressModelBase> addressBase)
        {

            var results = new List<ValidationErrorMessage>();

            foreach (var profileAddressCreateModel in addressBase)
            {
                results.AddRange(profileAddressCreateModel.Validate());
            }

            return results;
        }

        public static List<ValidationErrorMessage> Validate(this AddressModelBase addressBase)
        {

            var results = new AddressModelBaseFluentValidator().Validate(addressBase);

            return results.Errors.Select(error => {
                return new ValidationErrorMessage()
                {
                    Message = error.ErrorMessage,
                    StatusCode = "400"
                };
            }).ToList();
        }


    }

    public class AddressModelBaseFluentValidator : AbstractValidator<AddressModelBase>
    {

        public AddressModelBaseFluentValidator()
        {
            RuleFor(field => field.AddressName1).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(field => field.AddressName1)
                .MaximumLength(50).WithMessage("{PropertyName} can not exceed {MaxLength}.");

            RuleFor(field => field.AddressName2)
                .MaximumLength(50).WithMessage("{PropertyName} can not exceed {MaxLength}.");

            RuleFor(field => field.City).NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} can not exceed {MaxLength}.");

            RuleFor(field => field.StateAbreviation)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Length(2).WithMessage("{PropertyName} must contain 2 characters.");

            RuleFor(field => field.ZipCode).NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(IsZipcode).WithMessage("{PropertyName} is not a proper zipcode format.");
        }

        protected bool IsZipcode(string zipCode)
        {
            int TempInt;

            string ZipCodeTrim = zipCode.Trim();

            if ((ZipCodeTrim.Length == 5 || ZipCodeTrim.Length == 9) == false)
            {
                return false;
            }


            if (!int.TryParse(ZipCodeTrim, out TempInt))
            {
                return false;
            }

            return true;
        }
    }
}
