using Profiles.Models.Profiles;

namespace Profiles.Models.APIResponses
{
    public interface IProfileResponse: IResponseBase
    {
        IProfile Profile { get; set; }

    }
}