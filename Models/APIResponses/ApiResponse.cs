using Models.APIResponses;

namespace Profiles.Models.APIResponses
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public List<ErrorMessage> Messages { get; set; } = new List<ErrorMessage>();
    }
}
