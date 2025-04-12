using Moq;
using Repositories.Models.Profiles;
using Repositories.Profiles;
using Repositories.Profiles.Interfaces;

namespace UnitTests.Repositories.Profiles
{
    [TestClass]
    public class ProfileRepositoryProfileCreateUnitTests
    {

        const string ExceptionErrorMessage = "One or more errors occurred. (Exception of type 'System.Exception' was thrown.)";

        [TestMethod]
        public void Should_TheCreateAProfileAsync_ReturnsAProfile()
        {

            var sourceProfilesList = new List<ProfileDto>() {
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

            var sourceProfileToCreate = new ProfileCreateDto
            {
                FirstName = "Joe",
                LastName = "Smith",
                Active = true,
                Addresses =
                            new List<ProfileAddressCreateDto>(){ new ProfileAddressCreateDto() {
                                Address1 = "My Address 1",
                                Address2 = "My Address 2",
                                City = "My City",
                                StateAbrev = "NY", IsPrimary = true,
                                ZipCode = "54321"
                            }}
            };

            var mockProfileDataSource = new Mock<IProfileDataSource>();

            mockProfileDataSource.Setup(x => x.GetProfilesAsync()).ReturnsAsync(sourceProfilesList);

            var profileRepository = new ProfileRepository(mockProfileDataSource.Object);

            var actualResults = profileRepository.CreateProfileAsync(sourceProfileToCreate).Result;

            Assert.AreEqual(actualResults.LastName, sourceProfileToCreate.LastName);
            Assert.AreEqual(actualResults.ProfileId, 3);
            Assert.AreEqual(actualResults.FirstName, sourceProfileToCreate.FirstName);
            Assert.AreEqual(actualResults.Active, sourceProfileToCreate.Active);

            {
                var (actualAddress, expectedAddress) = (actualResults.Addresses[0], sourceProfileToCreate.Addresses[0]);

                Assert.AreEqual(actualAddress.AddressId, 12);
                Assert.AreEqual(actualAddress.Address1, expectedAddress.Address1);
                Assert.AreEqual(actualAddress.Address2, expectedAddress.Address2);
                Assert.AreEqual(actualAddress.City, expectedAddress.City);
                Assert.AreEqual(actualAddress.StateAbrev, expectedAddress.StateAbrev);
                Assert.AreEqual(actualAddress.ZipCode, expectedAddress.ZipCode);
            }
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
