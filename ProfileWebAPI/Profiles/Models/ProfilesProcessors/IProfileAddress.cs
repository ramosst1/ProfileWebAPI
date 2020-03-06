namespace Profiles.Models.Profiles
{
    public interface IProfileAddress: IAddress
    {
        int AddressId { get; set; }
        int ProfileId { get; set; }
        bool IsPrimary { get; set; }
        bool IsSecondary { get; set; }

    }
}