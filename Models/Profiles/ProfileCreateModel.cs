
namespace Models.Profiles
{
    public class ProfileCreateModel : ProfileModelBase
    {
        public List<ProfileAddressCreateModel> Addresses { get; set; } = new List<ProfileAddressCreateModel>();
    }
}
