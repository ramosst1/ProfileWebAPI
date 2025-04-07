namespace ProfileWebAPI.Models
{
    public class AddressDto
    {

        public bool IsPrimary { get; set; }
        public bool IsSecondary { get; set; }
        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string StateAbrev { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
    }
}
