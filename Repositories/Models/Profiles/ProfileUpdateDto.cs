
namespace Repositories.Models.Profiles
{
    public class ProfileUpdateDto : ProfileDtoBase
    {
        public int ProfileId { get; set; }

        public List<ProfileAddressUpdateDto> Addresses { get; set; } = new List<ProfileAddressUpdateDto>();

    }
}
