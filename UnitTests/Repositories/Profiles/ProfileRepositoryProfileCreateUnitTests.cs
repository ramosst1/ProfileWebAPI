using Moq;
using Repositories.Models.Profiles;
using Repositories.Profiles;

namespace UnitTests.Repositories.Profiles
{
    [TestClass]
    public class ProfileRepositoryProfileCreateUnitTests
    {

        const string ExceptionErrorMessage = "One or more errors occurred. (Exception of type 'System.Exception' was thrown.)";

        [TestMethod]
        public void Should_TheCreateAProfileAsync_ReturnsAProfile()
        {

            var profilesList = new List<ProfileDto>() {
                    new ProfileDto{ ProfileId = 1,
                        Addresses =
                            new List<ProfileAddressDto>(){ new ProfileAddressDto() {
                                AddressId = 10
                            }}
                    },
                    new ProfileDto{ ProfileId = 2,
                        Addresses =
                            new List<ProfileAddressDto>(){ new ProfileAddressDto() {
                                AddressId = 11
                            }}

                    },
            };

            var profileToCreate = new ProfileCreateDto
            {
                FirstName = "Joe",
                LastName = "Smith",
                Active = true,
                Addresses =
                            new List<ProfileAddressCreateDto>(){ new ProfileAddressCreateDto() {
                                AddressName1 = "My Address 1",
                                AddressName2 = "My Address 2",
                                City = "My City",
                                StateAbreviated = "NY", IsPrimary = true,
                                ZipCode = "54321"
                            }}
            };

            var mockProfileDataSource = new Mock<IProfileDataSource>();

            mockProfileDataSource.Setup(x => x.GetProfilesAsync()).ReturnsAsync(profilesList);

            var profileRepository = new ProfileRepository(mockProfileDataSource.Object);

            var actualResults = profileRepository.CreateProfileAsync(profileToCreate).Result;

            Assert.AreEqual(actualResults.LastName, profileToCreate.LastName);
            Assert.AreEqual(actualResults.ProfileId, 3);
            Assert.AreEqual(actualResults.FirstName, profileToCreate.FirstName);
            Assert.AreEqual(actualResults.Active, profileToCreate.Active);

            Assert.AreEqual(actualResults.Addresses[0].AddressId, 12);
            Assert.AreEqual(actualResults.Addresses[0].AddressName1, profileToCreate.Addresses[0].AddressName1);
            Assert.AreEqual(actualResults.Addresses[0].AddressName2, profileToCreate.Addresses[0].AddressName2);
            Assert.AreEqual(actualResults.Addresses[0].City, profileToCreate.Addresses[0].City);
            Assert.AreEqual(actualResults.Addresses[0].StateAbreviated, profileToCreate.Addresses[0].StateAbreviated);
            Assert.AreEqual(actualResults.Addresses[0].ZipCode, profileToCreate.Addresses[0].ZipCode);
        }

        [TestMethod]
        public void Should_TheCreateAProfileAsync_ThrowsAnExceptiopn()
        {
            var mockProfileDataSource = new Mock<IProfileDataSource>();

            mockProfileDataSource.Setup(x => x.GetProfilesAsync()).Throws<Exception>();

            var profileRepository = new ProfileRepository(mockProfileDataSource.Object);

            try
            {
                var actualResults = profileRepository.CreateProfileAsync(It.IsAny<ProfileCreateDto>()).Result;

                Assert.Fail("Exception not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ExceptionErrorMessage, ex.Message);
            }

        }

    }
}
