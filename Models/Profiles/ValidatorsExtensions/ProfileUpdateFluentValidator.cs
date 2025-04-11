using FluentValidation;
using Models.APIResponses;

namespace Models.Profiles.ValidatorsExtensions
{

    public static class ProfileUpdateValidator  {

        public static List<ValidationErrorMessage> Validate(this ProfileUpdateModel profileUpdateModel)
        {

            var results = ((ProfileModelBase)profileUpdateModel).Validate();

            results.AddRange(new ProfileUpdateFluentValidator().Validate(profileUpdateModel)
                .Errors.Select(error =>
                {
                    return new ValidationErrorMessage()
                    {
                        Message = error.ErrorMessage,
                        StatusCode = "400"
                    };
                }
                )
             );

            results.AddRange(profileUpdateModel.Addresses.Validate());

            return results;
        }

        public class ProfileUpdateFluentValidator : AbstractValidator<ProfileUpdateModel>
        {
            public ProfileUpdateFluentValidator()
            {
                RuleFor(field => field.ProfileId).Must(x => x > 0).WithMessage("{PropertyName} is not a valid id.");
            }
        }
    }
}
