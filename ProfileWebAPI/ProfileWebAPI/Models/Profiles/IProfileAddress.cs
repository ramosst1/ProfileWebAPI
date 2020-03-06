namespace ProfileWebAPI.Models.Profiles
{
    public interface IProfileAddress: IAddress
    {
        int AddressId { get; set; }
//        int ProfileId { get; set; }
    }
}