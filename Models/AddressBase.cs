namespace Models
{
    public abstract class AddressBase
    {

        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string StateAbrev { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
    }
}
