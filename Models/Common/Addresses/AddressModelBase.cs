namespace Models.Common.Addresses
{
    public abstract class AddressModelBase
    {
        private protected AddressModelBase() { }

        public string AddressName1 { get; set; } = string.Empty;
        public string AddressName2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string StateAbreviation { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
    }
}
