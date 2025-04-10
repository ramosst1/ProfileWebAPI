namespace Models.Profiles
{
    public class ProfileUpdateModel : ProfileModelBase
    {

        public int ProfileId { get; set; }

        public List<ProfileAddressUpdateModel> Addresses { get; set; } = new List<ProfileAddressUpdateModel>();

    }
}
