
namespace Models.Profiles
{
    public class ProfileCreateModel : ProfileBase
    {
        public List<ProfileAddressCreateModel> Addresses { get; set; } = new List<ProfileAddressCreateModel>();
    }
}
