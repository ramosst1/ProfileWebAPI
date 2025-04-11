using Models.APIResponses;

namespace Models.Profiles.ValidatorsExtensions
{

    public static class ProfileCreateValidator {

        public static List<ValidationErrorMessage> Validate(this ProfileCreateModel profileCreateModel)
        {
            var results = ((ProfileModelBase)profileCreateModel).Validate();


            results.AddRange(profileCreateModel.Addresses.Validate());

            return results;
        }
    }

}
