
namespace Models.Profiles
{
    public class ProfileModel: ProfileBase 
    {

        public int ProfileId { get; set; }

        public List<ProfileAddressModel> Addresses { get; set; } = new List<ProfileAddressModel>();


    }
}
