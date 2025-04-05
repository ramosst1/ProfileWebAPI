using Models.interfaces;

namespace Models.Profiles.interfaces
{
    public interface IProfileAddressCreateModel: IAddresModel
    {
        bool IsPrimary { get; set; }
        bool IsSecondary { get; set; }

    }
}