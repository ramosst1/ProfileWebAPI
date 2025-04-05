
using Models.Profiles.interfaces;

namespace Models.Profiles
{
    public class ProfileModel: ProfileBase, IProfileModel
    {

        public int ProfileId { get; set; }

        public List<ProfileAddressModel> Addresses { get; set; } = new List<ProfileAddressModel>();
    }
}
