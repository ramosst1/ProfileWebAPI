using Profiles.Models.APIResponses;
using Profiles.Models.Profiles;

namespace Profiles
{
    public interface IProfileAddressManager
    {
        IAddressesResponse Create(string address1, string address2, string city, string stateAbev, string zipCode, AddressTypes addressType);
    }
}