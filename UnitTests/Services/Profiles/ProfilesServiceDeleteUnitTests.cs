using Moq;
using Repositories.Profiles;
using Services.Profiles;

namespace UnitTests.Services.Profiles
{
    [TestClass]
    public class ProfilesServiceDeleteUnitTests
    {
        const string InternalErrorMessage = "Exception of type 'System.Exception' was thrown.";
        const string ExternalErrorMessage = "Exception of type 'System.Exception' was thrown.";

        [TestMethod]
        public void Should_TheDeleteAsync_ReturnsASuccessfulDelete()
        {

            var mockProfileRepository = new Mock<IProfileRepository>();

            mockProfileRepository.Setup(x => x.DeleteProfileAsync(It.IsAny<int>())).ReturnsAsync(true);

            var profileService = new ProfileService(mockProfileRepository.Object);

            var actualResults = profileService.DeleteProfilesAsync(2).Result;

            Assert.AreEqual(actualResults.Success, true);
            Assert.AreEqual(actualResults.Messages.Any(), false);
        }

        [TestMethod]
        public void Should_TheDeleteAsync_ReturnsUnSuccessfulDelete()
        {

            var mockProfileRepository = new Mock<IProfileRepository>();

            mockProfileRepository.Setup(x => x.DeleteProfileAsync(It.IsAny<int>())).ReturnsAsync(false);

            var profileService = new ProfileService(mockProfileRepository.Object);

            var actualResults = profileService.DeleteProfilesAsync(3).Result;

            Assert.AreEqual(actualResults.Success, false);
            Assert.AreEqual(actualResults.Messages[0].InternalMessage, "Unable to delete the profile");
            Assert.AreEqual(actualResults.Messages[0].ExternalMessage, "Unable to delete the profile");
        }

        [TestMethod]
        public void Should_TheDeleteAsync_ThrowssAnException()
        {

            var mockProfileRepository = new Mock<IProfileRepository>();

            mockProfileRepository.Setup(x => x.DeleteProfileAsync(It.IsAny<int>())).Throws<Exception>();

            var profileService = new ProfileService(mockProfileRepository.Object);

            var actualResults = profileService.DeleteProfilesAsync(2).Result;

            Assert.AreEqual(actualResults.Success, false);
            Assert.AreEqual(actualResults.Messages[0].InternalMessage, InternalErrorMessage);
            Assert.AreEqual(actualResults.Messages[0].ExternalMessage, ExternalErrorMessage);

        }
    }
}
