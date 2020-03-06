namespace ProfileWebAPI.Models
{
    public interface IAddress
    {
        string City { get; set; }
        string StateAbrev { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string ZipCode { get; set; }
        bool IsPrimary { get; set; }
        bool IsSecondary { get; set; }
    }
}