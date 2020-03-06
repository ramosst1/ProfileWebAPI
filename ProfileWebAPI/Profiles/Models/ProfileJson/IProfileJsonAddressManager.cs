using Profiles.Models.Profiles;

namespace Profiles.Models.ProfileJson
{
    interface IProfileJsonAddressManager
    {
        IProfileAddress Create(string address1, string address2, string city, string stateAbev, string zipCode, bool isPrimary, bool isSecondary);
    }
}