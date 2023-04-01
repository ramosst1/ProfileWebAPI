
namespace Repositories.Models.Profiles
{
    public class ProfileDto : ProfileDtoBase
    {
        public int ProfileId { get; set; }

        public List<ProfileAddressDto> Addresses { get; set; } = new List<ProfileAddressDto>();

    }
}
