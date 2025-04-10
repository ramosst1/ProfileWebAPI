using FluentValidation;
using Models.APIResponses;

namespace Models.Profiles.Validators
{

    public static class ProfileCreateValidator {

        public static List<ValidationErrorMessage> Validate(this ProfileCreateModel profileCreateModel)
        {
            var results = ((ProfileModelBase)profileCreateModel).Validate();

            results.AddRange(new ProfileCreateFluentValidator().Validate(profileCreateModel)
                .Errors.Select(error => {
                    return new ValidationErrorMessage()
                    {
                        Message = error.ErrorMessage,
                        StatusCode = "400"
                    };
                })
             );

            results.AddRange(profileCreateModel.Addresses.Validate());

            return results;
        }
    }

    public class ProfileCreateFluentValidator : AbstractValidator<ProfileCreateModel>
    {
        public ProfileCreateFluentValidator()
        {
            RuleForEach(x => x.Addresses).SetValidator(new ProfileAddressCreateFluentValidator());
        }
    }
}
