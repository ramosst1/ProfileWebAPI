using Models.Common.Addresses;

namespace Models.Profiles
{
    public class ProfileAddressCreateModel : AddressModelBase
    {
        public int AddressId { get; set; }

        public bool IsPrimary { get; set; } = false;
        public bool IsSecondary { get; set; } = false;
    }
}
