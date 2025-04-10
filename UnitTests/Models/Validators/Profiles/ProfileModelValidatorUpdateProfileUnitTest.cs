using Models.Profiles;
using Models.Profiles.Validators;

namespace UnitTests.Models.Validators.Profiles
{
    [TestClass]
    public class ProfileModelValidatorUpdateProfileUnitTest
    {

        [TestMethod]
        [DataRow(1,"John", "Smith", true)]
        [DataRow(1, "John", "Smith", false)]
        public void Should_TheProfileCreateModelValidatingHasInvalidData_ReturnsAValidInput(int propfileId, string firstName, string LastName, bool active)
        {
            var input = new ProfileUpdateModel
            {   ProfileId = propfileId,
                FirstName = firstName,
                LastName = LastName,
                Active = active
            };

            var actualResults = input.Validate();

            Assert.AreEqual(false, actualResults.Any());
        }

        [TestMethod]
        [DataRow(0, "", "Smith", true, "Profile Id is not a valid id.")]
        [DataRow(1, "", "Smith", true, "First Name is required.")]
        [DataRow(1, "J", "Smith", true, "First Name must be between 2 and 50 characters.")]
        [DataRow(1, "JohnXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "Smith", true, "First Name must be between 2 and 50 characters.")]
        [DataRow(1, "John", "", true, "Last Name is required.")]
        [DataRow(1, "John", "S", true, "Last Name must be between 2 and 50 characters.")]
        [DataRow(1, "John", "SmithXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", true, "Last Name must be between 2 and 50 characters.")]
        public void Should_TheProfileUpdateModelValidatingHasInvalidData_ReturnsAnInValidInput(
            int profileId, string firstName, string LastName, bool active, string expectedErrorMessage
         ){

            var input = new ProfileUpdateModel { ProfileId = profileId, FirstName = firstName, LastName = LastName, Active = active };

            var actualResults = input.Validate();

            Assert.AreEqual(true, actualResults.Any());
            Assert.AreEqual(true, actualResults.Exists(aItem => aItem.Message == expectedErrorMessage));

        }

    }
}
