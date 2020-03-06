using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profiles.Models
{
    public enum AddressTypes {
        Primary = 1, 
        Business = 2
    }
    public class Address : IAddress
    {

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateAbrev { get; set; }
        public string ZipCode { get; set; }
    }
}
