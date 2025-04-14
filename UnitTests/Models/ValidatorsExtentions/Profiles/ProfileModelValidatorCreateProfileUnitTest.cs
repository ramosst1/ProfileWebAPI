using Models.Profiles;
using Models.Profiles.ValidatorExtensions;

namespace UnitTests.Models.ValidatorsExtentions.Profiles
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

            Assert.AreEqual(true, actualResults.IsValid);
            Assert.AreEqual(false, actualResults.Messages.Any());
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

            Assert.AreEqual(false, actualResults.IsValid);
            Assert.AreEqual(true, actualResults.Messages.Any());
            Assert.AreEqual(true, actualResults.Messages.Exists(aItem => aItem.Message == expectedErrorMessage));
        }

        [TestMethod]
        public void Should_TheProfileUpdateModelValidatingHasInvalidDataWithAddress_ReturnsAnInValidAddressInput()
        {

            var input = new ProfileCreateModel
            {
                FirstName = "Joe",
                LastName = "Smith",
                Active = true,
                Addresses = {
                    new ProfileAddressCreateModel(){}
                }
            };

            var actualResults = input.Validate();

            Assert.AreEqual(false, actualResults.IsValid);
            Assert.AreEqual(true, actualResults.Messages.Exists(item => item.Message == "City is required."));

        }

    }
}
