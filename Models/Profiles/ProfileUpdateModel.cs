
namespace Models.Profiles
{
    public class ProfileUpdateModel : ProfileBase
    {

        public int ProfileId { get; set; }

        public List<ProfileAddressUpdateModel> Addresses { get; set; } = new List<ProfileAddressUpdateModel>();

    }
}
