
namespace Repositories.Models.Profiles
{
    public abstract class ProfileDtoBase
    {

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public bool Active { get; set; }


    }
}
