namespace ProfileWebAPI.Models
{
    public class AddressDto
    {

        public bool IsPrimary { get; set; }
        public bool IsSecondary { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateAbrev { get; set; }
        public string ZipCode { get; set; }
    }
}
