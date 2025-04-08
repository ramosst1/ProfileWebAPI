using Models.Profiles;
using Moq;
using Repositories.Models.Profiles;
using Repositories.Profiles;
using Services.Profiles;

namespace UnitTests.Services.Profiles
{
    [TestClass]
    public class ProfilesServiceUpdateProfileUnitTests
    {
        const string InternalErrorMessage = "Exception of type 'System.Exception' was thrown.";
        const string ExternalErrorMessage = "Exception of type 'System.Exception' was thrown.";

        [TestMethod]
        public void Should_TheUpdateAProfileAsync_ReturnsASuccessfulUpdate()
        {

            var profileDtoUpdateOutput = new ProfileDto {
                ProfileId = 1,
                FirstName = "UpdateFirst Name",
                LastName = "Update Last Name",
                Active = true,
                Addresses =
                    new List<ProfileAddressDto>(){ new () {
                        AddressId = 10,
                        Address1 = "Updated Address 1",
                        Address2 = "Updated Address 2",
                        City = "Updated City",
                        StateAbrev = "CT", IsPrimary = true,
                        ZipCode = "54321"
                    }}
            };

            var profileToUpdate = new ProfileUpdateModel
            {
                ProfileId = 1,
                FirstName = "UpdateFirst Name",
                LastName = "Update Last Name",
                Active = true,
                Addresses =
                    new List<ProfileAddressUpdateModel>(){ new () {
                        AddressId = 10,
                        AddressName1 = "Updated Address 1",
                        AddressName2 = "Updated Address 2",
                        City = "Updated City",
                        StateAbreviation = "CT", IsPrimary = true,
                        ZipCode = "54321"
                    }}
            };

            var mockProfileRepository = new Mock<IProfileRepository>();

            mockProfileRepository.Setup(x => x.UpdateProfileAsync(It.IsAny<ProfileUpdateDto>())).ReturnsAsync(profileDtoUpdateOutput);

            var profileService = new ProfileService(mockProfileRepository.Object);

            var actualResults = profileService.UpdateProfileAsync(profileToUpdate).Result;

            Assert.AreEqual(actualResults.Success, true);
            Assert.AreEqual(actualResults.ErrorMessages.Any(), false);

            Assert.AreEqual(actualResults.data.ProfileId, profileToUpdate.ProfileId);
            Assert.AreEqual(actualResults.data.FirstName, profileToUpdate.FirstName);
            Assert.AreEqual(actualResults.data.LastName, profileToUpdate.LastName);
            Assert.AreEqual(actualResults.data.Active, profileToUpdate.Active);

            {
                var (actualaddresses, expectedAddresses) = (actualResults.data.Addresses.FirstOrDefault(), profileToUpdate.Addresses[0]);

                Assert.AreEqual(actualaddresses.AddressId, expectedAddresses.AddressId);
                Assert.AreEqual(actualaddresses.AddressName1, expectedAddresses.AddressName1);
                Assert.AreEqual(actualaddresses.AddressName2, expectedAddresses.AddressName2);
                Assert.AreEqual(actualaddresses.City, expectedAddresses.City);
                Assert.AreEqual(actualaddresses.StateAbreviation, expectedAddresses.StateAbreviation);
                Assert.AreEqual(actualaddresses.ZipCode, expectedAddresses.ZipCode);
            }
        }

        [TestMethod]
        public void Should_TheUpdateAProfileAsync_ReturnsUnSuccessfulUpdateBecauseNoRecordFound()
        {

            var mockProfileRepository = new Mock<IProfileRepository>();

            mockProfileRepository.Setup(x => x.UpdateProfileAsync(It.IsAny<ProfileUpdateDto>())).ReturnsAsync((ProfileDto)null);

            var profileService = new ProfileService(mockProfileRepository.Object);

            var actualResults = profileService.UpdateProfileAsync(new ProfileUpdateModel()).Result;

            Assert.AreEqual(actualResults.Success, false);
            Assert.AreEqual(actualResults.ErrorMessages[0].InternalMessage, "Unable to update the profile");
            Assert.AreEqual(actualResults.ErrorMessages[0].ExternalMessage, "Unable to update the profile");
        }

        [TestMethod]
        public void Should_TheUpdateAProfileAsync_ThrowsAnException()
        {

            var mockProfileRepository = new Mock<IProfileRepository>();

            mockProfileRepository.Setup(x => x.UpdateProfileAsync(It.IsAny<ProfileUpdateDto>())).Throws<Exception>();

            var profileService = new ProfileService(mockProfileRepository.Object);

            var actualResults = profileService.UpdateProfileAsync(new ProfileUpdateModel()).Result;

            Assert.AreEqual(actualResults.Success, false);
            Assert.AreEqual(actualResults.data, null);
            Assert.AreEqual(actualResults.ErrorMessages[0].InternalMessage, InternalErrorMessage);
            Assert.AreEqual(actualResults.ErrorMessages[0].ExternalMessage, ExternalErrorMessage);
        }
    }
}
