namespace Models.Profiles.interfaces
{
    public interface IProfileModel
    {
        int ProfileId { get; set; }
        bool Active { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        List<ProfileAddressModel> Addresses { get; set; }
    }
}