
namespace Repositories.Models.Profiles
{
    public class ProfileCreateDto : ProfileDtoBase
    {
        public List<ProfileAddressCreateDto> Addresses { get; set; } = new List<ProfileAddressCreateDto>();

    }
}
