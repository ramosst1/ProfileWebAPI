using System.ComponentModel;

namespace Models
{
    public enum AddressTypes
    {
        Primary = 1,
        Business = 2
    }
    public abstract class AddressBase
    {

        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string StateAbrev { get; set; } = string.Empty;
        [DefaultValue("")]
        public string ZipCode { get; set; }
    }
}
