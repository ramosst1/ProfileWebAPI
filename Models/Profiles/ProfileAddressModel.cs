
namespace Models.Profiles
{
    public class ProfileAddressModel : AddressBase
    {

        public int ProfileId { get; set; }
        public int AddressId { get; set; }
        public bool IsPrimary { get; set; } = false;
        public bool IsSecondary { get; set; } = false;

    }
}
