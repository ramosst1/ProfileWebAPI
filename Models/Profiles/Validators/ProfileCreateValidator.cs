using FluentValidation;
using Models.APIResponses;

namespace Models.Profiles.Validators
{

    public static class ProfileCreateValidator {

        public static List<ValidationErrorMessage> Validate(this ProfileCreateModel profileCreateModel)
        {

            var results = new ProfileCreateFluentValidator().Validate(profileCreateModel);

            return results.Errors.Select(error => {
                return new ValidationErrorMessage()
                {
                    Message = error.ErrorMessage,
                    StatusCode = "400"
                };
            }).ToList();
        }
    }

    public class ProfileCreateFluentValidator : AbstractValidator<ProfileCreateModel>
    {
        public ProfileCreateFluentValidator()
        {
            Include(new ProfileModelBaseFluentValidator());
            RuleForEach(x => x.Addresses).SetValidator(new ProfileAddressCreateFluentValidator());
        }
    }
}
