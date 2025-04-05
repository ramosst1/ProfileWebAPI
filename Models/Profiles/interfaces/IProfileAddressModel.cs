using Models.interfaces;

namespace Models.Profiles.interfaces
{
    public interface IProfileAddressModel: IAddresModel
    {
        int AddressId { get; set; }
        bool IsPrimary { get; set; }
        bool IsSecondary { get; set; }
    }
}