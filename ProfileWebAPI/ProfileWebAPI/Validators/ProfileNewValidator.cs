using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ProfileWebAPI.Models.Profiles;

namespace ProfileWebAPI.Validators
{
    public class ProfileNewValidator: AbstractValidator<ProfileNew>
    {
        public ProfileNewValidator()
        {
            Include(new ProfileBaseDtoValidator());

            RuleForEach(x => x.Addresses).SetValidator(new ProfileAddressNewValidator());

        }

    }
}
