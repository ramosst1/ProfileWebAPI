using FluentValidation;
using ProfileWebAPI.Models.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileWebAPI.Validators
{
    public class ProfileAddressValidator : AbstractValidator<ProfileAddressDto>
    {

        public ProfileAddressValidator()
        {

            Include(new AddressValidator());

            RuleFor(field => field.AddressId).Must(x => x > -1).WithMessage("{PropertyName} is not a proper address id.");



        }
    }
}
