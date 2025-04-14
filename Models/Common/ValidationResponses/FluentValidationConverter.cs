using FluentValidation.Results;

namespace Models.Common.ValidationResponses
{
    public class FluentValidationConverter
    {
        private FluentValidationConverter(){}

        public static List<ValidationErrorMessage> ConvertToValidationErrors(List<ValidationFailure> validationFailures)
        {

            return validationFailures.Select(error => {
                return new ValidationErrorMessage()
                {
                    Message = error.ErrorMessage,
                    StatusCode = "400"
                };
            }).ToList();
        }

    }
}
