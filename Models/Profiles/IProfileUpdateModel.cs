using Models.Profiles.interfaces;

namespace Models.Profiles
{
    public interface IProfileUpdateModel
    {
        List<IProfileAddressUpdateModel> Addresses { get; set; }
        int ProfileId { get; set; }
    }
}