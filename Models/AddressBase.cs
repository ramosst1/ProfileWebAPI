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

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateAbrev { get; set; }
        [DefaultValue("")]
        public string ZipCode { get; set; }
    }
}
