
using Models.Profiles.interfaces;

namespace Models.Profiles
{
    public class ProfileUpdateModel : ProfileBase, IProfileUpdateModel
    {

        public int ProfileId { get; set; }

        public List<IProfileAddressUpdateModel> Addresses { get; set; } = new List<IProfileAddressUpdateModel>();

    }
}
