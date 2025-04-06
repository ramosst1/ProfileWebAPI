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
                    new List<ProfileAddressDto>(){ new ProfileAddressDto() {
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
                    new List<ProfileAddressUpdateModel>(){ new ProfileAddressUpdateModel() {
                        AddressId = 10,
                        Address1 = "Updated Address 1",
                        Address2 = "Updated Address 2",
                        City = "Updated City",
                        StateAbrev = "CT", IsPrimary = true,
                        ZipCode = "54321"
                    }}
            };

            var mockProfileRepository = new Mock<IProfileRepository>();

            mockProfileRepository.Setup(x => x.UpdateProfileAsync(It.IsAny<ProfileUpdateDto>())).ReturnsAsync(profileDtoUpdateOutput);

            var profileService = new ProfileService(mockProfileRepository.Object);

            var actualResults = profileService.UpdateProfileAsync(profileToUpdate).Result;

            Assert.AreEqual(actualResults.Success, true);
            Assert.AreEqual(actualResults.Messages.Any(), false);

            Assert.AreEqual(actualResults.data.ProfileId, profileToUpdate.ProfileId);
            Assert.AreEqual(actualResults.data.FirstName, profileToUpdate.FirstName);
            Assert.AreEqual(actualResults.data.LastName, profileToUpdate.LastName);
            Assert.AreEqual(actualResults.data.Active, profileToUpdate.Active);

            Assert.AreEqual(actualResults.data.Addresses[0].AddressId, profileToUpdate.Addresses[0].AddressId);
            Assert.AreEqual(actualResults.data.Addresses[0].Address1, profileToUpdate.Addresses[0].Address1);
            Assert.AreEqual(actualResults.data.Addresses[0].Address2, profileToUpdate.Addresses[0].Address2);
            Assert.AreEqual(actualResults.data.Addresses[0].City, profileToUpdate.Addresses[0].City);
            Assert.AreEqual(actualResults.data.Addresses[0].StateAbrev, profileToUpdate.Addresses[0].StateAbrev);
            Assert.AreEqual(actualResults.data.Addresses[0].ZipCode, profileToUpdate.Addresses[0].ZipCode);

        }

        [TestMethod]
        public void Should_TheUpdateAProfileAsync_ReturnsUnSuccessfulUpdateBecauseNoRecordFound()
        {

            var mockProfileRepository = new Mock<IProfileRepository>();

            mockProfileRepository.Setup(x => x.UpdateProfileAsync(It.IsAny<ProfileUpdateDto>())).ReturnsAsync((ProfileDto)null);

            var profileService = new ProfileService(mockProfileRepository.Object);

            var actualResults = profileService.UpdateProfileAsync(new ProfileUpdateModel()).Result;

            Assert.AreEqual(actualResults.Success, false);
            Assert.AreEqual(actualResults.Messages[0].InternalMessage, "Unable to update the profile");
            Assert.AreEqual(actualResults.Messages[0].ExternalMessage, "Unable to update the profile");
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
            Assert.AreEqual(actualResults.Messages[0].InternalMessage, InternalErrorMessage);
            Assert.AreEqual(actualResults.Messages[0].ExternalMessage, ExternalErrorMessage);
        }
    }
}
