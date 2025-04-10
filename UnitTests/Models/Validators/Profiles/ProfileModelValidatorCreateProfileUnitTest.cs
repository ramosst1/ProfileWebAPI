using Models.Profiles;
using Models.Profiles.Validators;

namespace UnitTests.Models.Validators.Profiles
{
    [TestClass]
    public class ProfileModelValidatorCreateProfileUnitTest
    {
        [TestMethod]
        [DataRow("John", "Smith", true)]
        [DataRow("John", "Smith", false)]
        public void Should_TheProfileCreateModelValidatingHasInvalidData_ReturnsAValidInput(string firstName, string LastName, bool active)
        {
            var input = new ProfileCreateModel
            {
                FirstName = firstName,
                LastName = LastName,
                Active = active
            };

            var actualResults = input.Validate();

            Assert.AreEqual(false, actualResults.Any());
        }

        [TestMethod]
        [DataRow("", "Smith", true, "First Name is required.")]
        [DataRow("J", "Smith", true, "First Name must be between 2 and 50 characters.")]
        [DataRow("JohnXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "Smith", true, "First Name must be between 2 and 50 characters.")]
        [DataRow("John", "", true, "Last Name is required.")]
        [DataRow("John", "S", true, "Last Name must be between 2 and 50 characters.")]
        [DataRow("John", "SmithXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", true, "Last Name must be between 2 and 50 characters.")]
        public void Should_TheProfileCreateModelValidatingHasInvalidData_ReturnsAnInValidInput(string firstName, string LastName, bool active, string expectedErrorMessage)
        {

            var input = new ProfileCreateModel { FirstName = firstName, LastName = LastName, Active = active };

            var actualResults = input.Validate();

            Assert.AreEqual(true, actualResults.Any());
            Assert.AreEqual(true, actualResults.Exists(aItem => aItem.Message == expectedErrorMessage));

        }

    }
}
