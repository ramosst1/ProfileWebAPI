using Models.Profiles;
using WebAPI.Validators;

namespace UnitTests.WebAPI.Validators.Profiles
{
    [TestClass]
    public class ProfileModelValidatorCreateProfileAddressUnitTest
    {

        [TestMethod]
        [DataRow("My Address1", "My Address2", "My City", "NY", "12345", true, false)]
        [DataRow("My Address1", "My Address2", "My City", "NY", "123456789", true, false)]
        public void Should_TheProfileCreateAddressModelValidation_ReturnsAValidInputs(
            string address1, string address2, string city, string stateAbrev, string zipCode, bool isPrimary, bool isSecondary
        ){
            var validator = new ProfileAddressCreateValidator();

            var input = new ProfileAddressCreateModel
            {
                 Address1 = address1,
                 Address2 = address2,
                 City = city,
                 StateAbrev = stateAbrev,
                 ZipCode = zipCode,
                 IsPrimary =isPrimary,
                 IsSecondary = isSecondary
            };

            var actualResults = validator.Validate(input);

            Assert.AreEqual(true, actualResults.IsValid);
        }

        [TestMethod]
        [DataRow("", "My Address2", "My City", "NY", "12345", true, false, "Address1 is required.")]
        [DataRow("My Address1XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "My Address2", "My City", "NY", "12345", true, false, "Address1 can not exceed 50.")]
        [DataRow("My Address1", "My Address2XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "My City", "NY", "12345", true, false, "Address2 can not exceed 50.")]
        [DataRow("My Address1", "My Address2", "", "NY", "12345", true, false, "City is required.")]
        [DataRow("My Address1", "My Address2", "My CityXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "NY", "12345", true, false, "City can not exceed 50.")]
        [DataRow("My Address1", "My Address2", "My City", "", "12345", true, false, "State Abrev is required.")]
        [DataRow("My Address1", "My Address2", "My City", "NYX", "12345", true, false, "State Abrev must contain 2 characters.")]
        [DataRow("My Address1", "My Address2", "My City", "NY", "", true, false, "Zip Code is required.")]
        [DataRow("My Address1", "My Address2", "My City", "NY", "123456", true, false, "Zip Code is not a proper zipcode format.")]
        [DataRow("My Address1", "My Address2", "My City", "NY", "12345678", true, false, "Zip Code is not a proper zipcode format.")]
        [DataRow("My Address1", "My Address2", "My City", "NY", "12345678", false, false, "Select either a primary or a secondary address type.")]
        [DataRow("My Address1", "My Address2", "My City", "NY", "12345678", true, true, "Select either a primary or a secondary address type.")]
        public void Should_TheProfileCreateAddressModelValidation_ReturnsAnInValidInputs(
            string address1, string address2, string city, string stateAbrev, string zipCode, bool isPrimary, bool isSecondary, string expectedErrorMessage
        )
        {
            var validator = new ProfileAddressCreateValidator();

            var input = new ProfileAddressCreateModel
            {
                Address1 = address1,
                Address2 = address2,
                City = city,
                StateAbrev = stateAbrev,
                ZipCode = zipCode,
                IsPrimary = isPrimary,
                IsSecondary = isSecondary
            };

            var actualResults = validator.Validate(input);

            Assert.AreEqual(false, actualResults.IsValid);
            Assert.AreEqual(true, actualResults.Errors.Exists(aItem => aItem.ErrorMessage == expectedErrorMessage));
        }
    }
}
