using Models.Common.Addresses;

namespace Models.Profiles
{
    public class ProfileAddressUpdateModel : AddressModelBase
    {
        public int ProfileId { get; set; }
        public int AddressId { get; set; }
        public bool IsPrimary { get; set; } = false;
        public bool IsSecondary { get; set; } = false;

    }
}
