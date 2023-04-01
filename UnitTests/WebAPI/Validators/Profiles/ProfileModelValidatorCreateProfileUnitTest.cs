using Models.Profiles;
using WebAPI.Validators;

namespace UnitTests.WebAPI.Validators.Profiles
{
    [TestClass]
    public class ProfileModelValidatorCreateProfileUnitTest
    {
        [TestMethod]
        [DataRow("John", "Smith", true)]
        [DataRow("John", "Smith", false)]
        public void Should_TheProfileCreateModelValidatingHasInvalidData_ReturnsAValidInput(string firstName, string LastName, bool active)
        {
            var validator = new ProfileCreateValidator();

            var input = new ProfileCreateModel
            {
                FirstName = firstName,
                LastName = LastName,
                Active = active
            };

            var actualResults = validator.Validate(input);

            Assert.AreEqual(true, actualResults.IsValid);
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
            var validator = new ProfileCreateValidator();

            var input = new ProfileCreateModel { FirstName = firstName, LastName = LastName, Active = active };

            var actualResults = validator.Validate(input);

            Assert.AreEqual(false, actualResults.IsValid);
            Assert.AreEqual(true, actualResults.Errors.Exists(aItem => aItem.ErrorMessage == expectedErrorMessage));

        }

    }
}
