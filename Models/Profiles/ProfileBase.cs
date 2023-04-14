
namespace Models.Profiles
{
    public abstract class ProfileBase
    {

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}
