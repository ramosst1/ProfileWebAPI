using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ProfileWebAPI.Models.Profiles;

namespace ProfileWebAPI.Validators
{
    public class ProfileAddressNewValidator: AbstractValidator<ProfileAddressNewDto>
    {

        public ProfileAddressNewValidator()
        {
            Include(new AddressValidator());


        }
    }
}
