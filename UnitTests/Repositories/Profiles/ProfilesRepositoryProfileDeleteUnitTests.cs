using Moq;
using Repositories.Models.Profiles;
using Repositories.Profiles;
using Repositories.Profiles.Interfaces;

namespace UnitTests.Repositories.Profiles
{

    [TestClass]
    public class ProfilesRepositoryProfileDeleteUnitTests
    {
        const string ExceptionErrorMessage = "One or more errors occurred. (Exception of type 'System.Exception' was thrown.)";

        [TestMethod]
        public void Should_TheDeleteProfileAsync_ReturnsASuccessfulDelete() {

            var expectedProfiles = new List<ProfileDto>() {
                new ProfileDto{ ProfileId = 1},
                new ProfileDto{ ProfileId = 2},
            };

            var mockProfileDataSource = new Mock<IProfileDataSource>();

            mockProfileDataSource.Setup(x => x.GetProfilesAsync()).ReturnsAsync(expectedProfiles);
            mockProfileDataSource.Setup(x => x.WriteJsonToFileAsync(It.IsAny<string>()));

            var profileRepository = new ProfileRepository(mockProfileDataSource.Object);

            var actualResults = profileRepository.DeleteProfileAsync(2).Result;

            Assert.AreEqual(actualResults, true);
        }

        [TestMethod]
        public void Should_TheProfileDeleteAsync_ReturnsAnException()
        {

            var expectedProfiles = new List<ProfileDto>() {
                new ProfileDto{ ProfileId = 1},
                new ProfileDto{ ProfileId = 2},
            };

            var mockProfileDataSource = new Mock<IProfileDataSource>();

            mockProfileDataSource.Setup(x => x.GetProfilesAsync()).Throws<Exception>();

            var profileRepository = new ProfileRepository(mockProfileDataSource.Object);

            try
            {
                var actualResults = profileRepository.DeleteProfileAsync(3).Result;

                Assert.Fail("Exception not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ExceptionErrorMessage, ex.Message);
            }
        }

    }
}
