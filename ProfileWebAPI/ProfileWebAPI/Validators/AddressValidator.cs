using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ProfileWebAPI.Models;

namespace ProfileWebAPI.Validators
{
    public class AddressValidator: AbstractValidator<AddressDto>
    {

        public AddressValidator()
        {
            RuleFor(field => field.Address1).NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(field => field.Address2)
                .MaximumLength(50).WithMessage("{PropertyName} can not exceed {MaxLength}.");

            RuleFor(field => field.City).NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} can not exceed {MaxLength}.");

            RuleFor(field => field.StateAbrev)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Length(2).WithMessage("{PropertyName} must contain {Length} characters.");

            RuleFor(field => field.ZipCode).NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(IsZipcode).WithMessage("{PropertyName} is not a proper zipcode.");

            RuleFor(field => field).Must(IsPrimaryOrSecondary).WithMessage("Select either a primary or a secondary address type");

        }

        protected bool IsZipcode(string zipCode)
        {
            int TempInt;

            string ZipCodeTrim = zipCode.Trim();

            if ((ZipCodeTrim.Length == 5 || ZipCodeTrim.Length == 9) == false) {

                return false;
            }


            if (!int.TryParse(ZipCodeTrim, out TempInt)) {
                return false;
            }


            return true;
        }

        protected bool IsPrimaryOrSecondary(AddressDto aAddress) {

            if (aAddress.IsPrimary == aAddress.IsSecondary) {
                return false;
            }

            return true;
        }
    }
}
