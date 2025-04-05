
using Models.Profiles.interfaces;

namespace Models.Profiles
{
    public class ProfileAddressUpdateModel : AddressBase, IProfileAddressUpdateModel
    {
        public int ProfileId { get; set; }
        public int AddressId { get; set; }
        public bool IsPrimary { get; set; } = false;
        public bool IsSecondary { get; set; } = false;

    }
}
