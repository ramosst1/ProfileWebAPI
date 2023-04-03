using FluentValidation;
using Models;

namespace WebAPI.Validators
{
    public class AddressBaseValidator : AbstractValidator<AddressBase>
    {

        public AddressBaseValidator()
        {
            RuleFor(field => field.Address1).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(field => field.Address1)
                .MaximumLength(50).WithMessage("{PropertyName} can not exceed {MaxLength}.");

            RuleFor(field => field.Address2)
                .MaximumLength(50).WithMessage("{PropertyName} can not exceed {MaxLength}.");

            RuleFor(field => field.City).NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} can not exceed {MaxLength}.");

            RuleFor(field => field.StateAbrev)
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
