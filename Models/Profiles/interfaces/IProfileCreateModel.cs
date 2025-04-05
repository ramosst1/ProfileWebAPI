namespace Models.Profiles.interfaces
{
    public interface IProfileCreateModel
    {
        bool Active { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        List<IProfileAddressCreateModel> Addresses { get; set; }

    }
}