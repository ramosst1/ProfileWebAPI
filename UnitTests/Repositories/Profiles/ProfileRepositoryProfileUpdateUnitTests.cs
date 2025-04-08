using Moq;
using Repositories.Models.Profiles;
using Repositories.Profiles;

namespace UnitTests.Repositories.Profiles
{
    [TestClass]
    public class ProfileRepositoryProfileUpdateUnitTests
    {

        const string ExceptionErrorMessage = "One or more errors occurred. (Exception of type 'System.Exception' was thrown.)";

        [TestMethod]
        public void Should_TheUpdateAProfileAsync_ReturnsAProfile()
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
                                AddressId = 11,
                                Address1 = "My Address 1",
                                Address2 = "My Address 2",
                                City = "My City",
                                StateAbrev = "NY", IsPrimary = true,
                                ZipCode = "54321"
                            }}

                    },
            };

            var expectedProfile = new ProfileDto
            {
                ProfileId = 2,
                FirstName = "Joe2",
                LastName = "Smith2",
                Active = true,
                Addresses =
                            new List<ProfileAddressDto>(){ new ProfileAddressDto() {
                                AddressId = 11,
                                Address1 = "My Updated Address 1",
                                Address2 = "My Update Address 2",
                                City = "My Update City",
                                StateAbrev = "CT", IsPrimary = true,
                                ZipCode = "98765"
                            }}
            };

            var profileToUpdate = new ProfileUpdateDto
            {
                ProfileId = 2,
                FirstName = "Joe2",
                LastName = "Smith2",
                Active = true,
                Addresses =
                            new List<ProfileAddressUpdateDto>(){ new ProfileAddressUpdateDto() {
                                AddressId = 11,
                                Address1 = "My Updated Address 1",
                                Address2 = "My Update Address 2",
                                City = "My Update City",
                                StateAbrev = "CT", IsPrimary = true,
                                ZipCode = "98765"
                            }}
            };

            var mockProfileDataSource = new Mock<IProfileDataSource>();

            mockProfileDataSource.Setup(x => x.GetProfilesAsync()).ReturnsAsync(profilesList);

            var profileRepository = new ProfileRepository(mockProfileDataSource.Object);

            var actualResults = profileRepository.UpdateProfileAsync(profileToUpdate).Result;




            Assert.AreEqual(actualResults.ProfileId, expectedProfile.ProfileId);
            Assert.AreEqual(actualResults.FirstName, expectedProfile.FirstName);
            Assert.AreEqual(actualResults.LastName, expectedProfile.LastName);
            Assert.AreEqual(actualResults.Active, expectedProfile.Active);

            { 
                var (actualAddress, expectedAddress) = (actualResults.Addresses[0], expectedProfile.Addresses[0]);

                Assert.AreEqual(actualAddress.AddressId, expectedAddress.AddressId);
                Assert.AreEqual(actualAddress.Address1, expectedAddress.Address1);
                Assert.AreEqual(actualAddress.Address2, expectedAddress.Address2);
                Assert.AreEqual(actualAddress.City, expectedAddress.City);
                Assert.AreEqual(actualAddress.StateAbrev, expectedAddress.StateAbrev);
                Assert.AreEqual(actualAddress.ZipCode, expectedAddress.ZipCode);
            }
        }

        [TestMethod]
        public void Should_TheUpdateAProfileAsync_ReturnsNoProfileBecauseNoProfileFoundToUpdate()
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

            var profileToUpdate = new ProfileUpdateDto
            {
                ProfileId = 3,
            };

            var mockProfileDataSource = new Mock<IProfileDataSource>();

            mockProfileDataSource.Setup(x => x.GetProfilesAsync()).ReturnsAsync(profilesList);

            var profileRepository = new ProfileRepository(mockProfileDataSource.Object);

            var actualResults = profileRepository.UpdateProfileAsync(profileToUpdate).Result;

            Assert.IsNull(actualResults);  
        }

        [TestMethod]
        public void Should_TheUpdateAProfileAsync_ThrowsAnExceptiopn()
        {
            var mockProfileDataSource = new Mock<IProfileDataSource>();

            mockProfileDataSource.Setup(x => x.GetProfilesAsync()).Throws<Exception>();

            var profileRepository = new ProfileRepository(mockProfileDataSource.Object);

            try
            {
                var actualResults = profileRepository.UpdateProfileAsync(It.IsAny<ProfileUpdateDto>()).Result;

                Assert.Fail("Exception not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ExceptionErrorMessage, ex.Message);
            }

        }

    }
}
