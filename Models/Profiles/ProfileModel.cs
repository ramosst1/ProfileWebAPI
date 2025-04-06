
namespace Models.Profiles
{
    public class ProfileModel: ProfileModelBase
    {

        public int ProfileId { get; set; }

        public List<ProfileAddressModel> Addresses { get; set; } = new List<ProfileAddressModel>();
    }
}
