using FluentValidation;
using Models.APIResponses;

namespace Models.Profiles.Validators
{

    public static class ProfileUpdateValidator  {

        public static List<ValidationErrorMessage> Validate(this ProfileUpdateModel profileUpdateModel)
        {

            var results = new ProfileUpdateFluentValidator().Validate(profileUpdateModel);

            return results.Errors.Select(error => {
                return new ValidationErrorMessage()
                {
                    Message = error.ErrorMessage,
                    StatusCode = "400"
                };
            }).ToList();
        }
    }

    public class ProfileUpdateFluentValidator : AbstractValidator<ProfileUpdateModel>
    {
        public ProfileUpdateFluentValidator()
        {
            Include(new ProfileModelBaseFluentValidator());

            RuleFor(field => field.ProfileId).Must(x => x > 0).WithMessage("{PropertyName} is not a valid id.");
            RuleForEach(x => x.Addresses).SetValidator(new ProfileAddressUpdateFluentValidator());

        }
    }

}
