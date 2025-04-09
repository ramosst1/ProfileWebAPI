namespace Models.Profiles
{
    public abstract class ProfileModelBase
    {
        private protected ProfileModelBase(){}

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}
