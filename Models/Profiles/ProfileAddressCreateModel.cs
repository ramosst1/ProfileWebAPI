
namespace Models.Profiles
{
    public class ProfileAddressCreateModel : AddressBase
    {
        public int AddressId { get; set; }

        public bool IsPrimary { get; set; } = false;
        public bool IsSecondary { get; set; } = false;
    }
}
