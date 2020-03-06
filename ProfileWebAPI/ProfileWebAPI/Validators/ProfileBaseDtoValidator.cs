using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ProfileWebAPI.Models.Profiles;

namespace ProfileWebAPI.Validators
{
    public class ProfileBaseDtoValidator: AbstractValidator<ProfileBase>
    {
        public ProfileBaseDtoValidator()
        {

            RuleFor(field => field.FirstName).NotEmpty().WithMessage("{PropertyName} is required.")
                .Length(2, 50).WithMessage("{PropertyName} Must be between {MinLength} and {MaxLength} characters ");
            RuleFor(field => field.LastName).NotEmpty().WithMessage("{PropertyName} is required.")
                .Length(2, 50).WithMessage("{PropertyName} Must be between {MinLength} and {MaxLength} characters ");

        }
    }
}
