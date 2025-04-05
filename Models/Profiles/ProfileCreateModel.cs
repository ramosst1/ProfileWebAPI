
using Models.Profiles.interfaces;

namespace Models.Profiles
{
    public class ProfileCreateModel : ProfileBase, IProfileCreateModel
    {
        public List<IProfileAddressCreateModel> Addresses { get; set; } = new List<IProfileAddressCreateModel>();
    }
}
