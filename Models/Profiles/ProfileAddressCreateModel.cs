
namespace Models.Profiles
{
    public class ProfileAddressCreateModel : AddressBase
    {
        public bool IsPrimary { get; set; } = false;
        public bool IsSecondary { get; set; } = false;

    }
}
