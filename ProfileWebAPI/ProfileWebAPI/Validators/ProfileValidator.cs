using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ProfileWebAPI.Models.Profiles;

namespace ProfileWebAPI.Validators
{
    public class ProfileValidator: AbstractValidator<ProfileDto>
    {

        public ProfileValidator()
        {

            Include(new ProfileBaseDtoValidator());

            RuleFor(field => field.ProfileId).Must(x => x > 0).WithMessage("{PropertyName} is not a proper profle id.");

            RuleForEach(x => x.Addresses).SetValidator(new ProfileAddressValidator());

        }
    }
}
