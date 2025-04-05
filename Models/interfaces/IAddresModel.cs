namespace Models.interfaces
{
    public interface IAddresModel
    {
        string Address1 { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        string StateAbrev { get; set; }
        string ZipCode { get; set; }
    }
}