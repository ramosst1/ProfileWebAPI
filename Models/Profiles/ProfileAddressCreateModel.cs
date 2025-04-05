
using Models.Profiles.interfaces;

namespace Models.Profiles
{
    public class ProfileAddressCreateModel : AddressBase, IProfileAddressCreateModel
    {
        public int AddressId { get; set; }

        public bool IsPrimary { get; set; } = false;
        public bool IsSecondary { get; set; } = false;
    }
}
