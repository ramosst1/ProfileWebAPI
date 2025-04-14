
namespace Models.Common.ValidationResponses
{
    public class ValidationResponse
    {
        
        public bool IsValid { get { return !Messages.Any(); } }
        
        public List<ValidationErrorMessage> Messages { get; set; } = new ();

    }
}
