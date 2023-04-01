using Models.Profiles;
using Moq;
using Repositories.Models.Profiles;
using Repositories.Profiles;
using Services.Profiles;

namespace UnitTests.Services.Profiles
{
    [TestClass]
    public class ProfilesServiceCreateProfileUnitTests
    {

        const string InternalErrorMessage = "Exception of type 'System.Exception' was thrown.";
        const string ExternalErrorMessage = "Exception of type 'System.Exception' was thrown.";


        [TestMethod]
        public void Should_TheCreateAProfileAsync_ReturnsASuccessfulUpdate()
        {

            var profileDtoCreateOutput = new ProfileDto
            {
                ProfileId = 1,
                FirstName = "My First Name",
                LastName = "My Last Name",
                Active = true,
                Addresses =
                    new List<ProfileAddressDto>(){ new ProfileAddressDto() {
                        AddressId = 10,
                        Address1 = "My Address 1",
                        Address2 = "My Address 2",
                        City = "My City",
                        StateAbrev = "CT", IsPrimary = true,
                        ZipCode = "54321"
                    }}
            };

            var profileToCreate = new ProfileCreateModel
            {
                FirstName = "My First Name",
                LastName = "My Last Name",
                Active = true,
                Addresses =
                    new List<ProfileAddressCreateModel>(){ new ProfileAddressCreateModel() {
                        Address1 = "My Address 1",
                        Address2 = "My Address 2",
                        City = "My City",
                        StateAbrev = "CT", IsPrimary = true,
                        ZipCode = "54321"
                    }}
            };

            var mockProfileRepository = new Mock<IProfileRepository>();

            mockProfileRepository.Setup(x => x.CreateProfileAsync(It.IsAny<ProfileCreateDto>())).ReturnsAsync(profileDtoCreateOutput);

            var profileService = new ProfileService(mockProfileRepository.Object);

            var actualResults = profileService.CreateProfileAsync(profileToCreate).Result;

            Assert.AreEqual(actualResults.Success, true);
            Assert.AreEqual(actualResults.Messages.Any(), false);

            Assert.AreEqual(actualResults.Profile.ProfileId, 1);
            Assert.AreEqual(actualResults.Profile.FirstName, profileToCreate.FirstName);
            Assert.AreEqual(actualResults.Profile.LastName, profileToCreate.LastName);
            Assert.AreEqual(actualResults.Profile.Active, profileToCreate.Active);

            Assert.AreEqual(actualResults.Profile.Addresses[0].AddressId, 10);
            Assert.AreEqual(actualResults.Profile.Addresses[0].Address1, profileToCreate.Addresses[0].Address1);
            Assert.AreEqual(actualResults.Profile.Addresses[0].Address2, profileToCreate.Addresses[0].Address2);
            Assert.AreEqual(actualResults.Profile.Addresses[0].City, profileToCreate.Addresses[0].City);
            Assert.AreEqual(actualResults.Profile.Addresses[0].StateAbrev, profileToCreate.Addresses[0].StateAbrev);
            Assert.AreEqual(actualResults.Profile.Addresses[0].ZipCode, profileToCreate.Addresses[0].ZipCode);
        }

        [TestMethod]
        public void Should_TheCreateAProfileAsync_ThrowsAnException()
        {

            var mockProfileRepository = new Mock<IProfileRepository>();

            mockProfileRepository.Setup(x => x.CreateProfileAsync(It.IsAny<ProfileCreateDto>())).Throws<Exception>();

            var profileService = new ProfileService(mockProfileRepository.Object);

            var actualResults = profileService.CreateProfileAsync(new ProfileCreateModel()).Result;

            Assert.AreEqual(actualResults.Success, false);
            Assert.AreEqual(actualResults.Profile, null);
            Assert.AreEqual(actualResults.Messages[0].InternalMessage, InternalErrorMessage);
            Assert.AreEqual(actualResults.Messages[0].ExternalMessage, ExternalErrorMessage);
        }

    }
}
