using FluentValidation.Results;

namespace Models.Common.ValidationResponses
{
    public class FluentValidationConverter
    {
        private FluentValidationConverter(){}

        public static List<ValidationErrorMessageModel> ConvertToValidationErrors(List<ValidationFailure> validationFailures)
        {

            return validationFailures.Select(error => {
                return new ValidationErrorMessageModel()
                {
                    Message = error.ErrorMessage,
                    StatusCode = "400"
                };
            }).ToList();
        }

    }
}
