namespace ProfileWebAPI.Models
{
    public class AddressDto
    {

        public bool IsPrimary { get; set; }
        public bool IsSecondary { get; set; }
        public string AddressName1 { get; set; } = string.Empty;
        public string AddressName2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string StateAbreviated { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
    }
}
