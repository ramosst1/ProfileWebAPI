using Models.Profiles;
using Models.Profiles.ValidatorExtensions;

namespace UnitTests.Models.ValidatorsExtentions.Profiles
{
    [TestClass]
    public class ProfileModelValidatorUpdateProfileAddressUnitTest
    {

        [TestMethod]
        [DataRow(1,10, "My Address1", "My Address2", "My City", "NY", "12345", true, false)]
        [DataRow(1, 10, "My Address1", "", "My City", "NY", "12345", true, false)]
        [DataRow(1,10, "My Address1", "My Address2", "My City", "NY", "123456789", true, false)]
        public void Should_TheProfileUpdateAddressModelValidation_ReturnsAValidInputs(
            int profileId, int addressId, string address1, string address2, string city, string stateAbrev, string zipCode, bool isPrimary, bool isSecondary
        ){

            var input = new ProfileAddressUpdateModel
            {
                 ProfileId = profileId,
                 AddressId = addressId,
                 AddressName1 = address1,
                 AddressName2 = address2,
                 City = city,
                 StateAbreviation = stateAbrev,
                 ZipCode = zipCode,
                 IsPrimary =isPrimary,
                 IsSecondary = isSecondary
            };

            var actualResults = input.Validate();

            Assert.AreEqual(false, actualResults.Any());
        }

        [TestMethod]
        [DataRow(0, 10, "My Address1", "My Address2", "My City", "NY", "12345", true, false, "Profile Id is not a proper id.")]
        [DataRow(1, 0, "My Address1", "My Address2", "My City", "NY", "12345", true, false, "Address Id is not a proper id.")]
        [DataRow(1, 10, "", "My Address2", "My City", "NY", "12345", true, false, "Address Name1 is required.")]
        [DataRow(1, 10, "My Address1XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "My Address Name2", "My City", "NY", "12345", true, false, "Address Name1 can not exceed 50.")]
        [DataRow(1, 10, "My Address1", "My Address2XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "My City", "NY", "12345", true, false, "Address Name2 can not exceed 50.")]
        [DataRow(1, 10, "My Address1", "My Address2", "", "NY", "12345", true, false, "City is required.")]
        [DataRow(1, 10, "My Address1", "My Address2", "My CityXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "NY", "12345", true, false, "City can not exceed 50.")]
        [DataRow(1, 10, "My Address1", "My Address2", "My City", "", "12345", true, false, "State Abreviation is required.")]
        [DataRow(1, 10, "My 1, ", "My Address2", "My City", "NYX", "12345", true, false, "State Abreviation must contain 2 characters.")]
        [DataRow(1, 10, "My Address1", "My Address2", "My City", "NY", "", true, false, "Zip Code is required.")]
        [DataRow(1, 10, "My Address1", "My Address2", "My City", "NY", "123456", true, false, "Zip Code is not a proper zipcode format.")]
        [DataRow(1, 10, "My Address1", "My Address2", "My City", "NY", "12345678", true, false, "Zip Code is not a proper zipcode format.")]
        [DataRow(1, 10, "My Address1", "My Address2", "My City", "NY", "12345678", false, false, "Select either a primary or a secondary address type.")]
        [DataRow(1, 10, "My Address1", "My Address2", "My City", "NY", "12345678", true, true, "Select either a primary or a secondary address type.")]
        public void Should_TheProfileUpdateAddressModelValidation_ReturnsAnInValidInputs(
            int profileId, int addressId, string address1, string address2, string city, string stateAbrev, string zipCode, bool isPrimary, bool isSecondary, string expectedErrorMessage
        )
        {

            var input = new ProfileAddressUpdateModel
            {
                ProfileId = profileId,
                AddressId = addressId,
                AddressName1 = address1,
                AddressName2 = address2,
                City = city,
                StateAbreviation = stateAbrev,
                ZipCode = zipCode,
                IsPrimary = isPrimary,
                IsSecondary = isSecondary
            };

            var actualResults = input.Validate();

            Assert.AreEqual(true, actualResults.Any());
            Assert.AreEqual(true, actualResults.Exists(aItem => aItem.Message == expectedErrorMessage));
        }
    }
}
