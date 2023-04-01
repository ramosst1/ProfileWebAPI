using ProfileWebAPI.Models;

namespace Repositories.Models.Profiles
{
    public class ProfileAddressDto : AddressDto
    {

        public int ProfileId { get; set; }
        public int AddressId { get; set; }

    }
}
