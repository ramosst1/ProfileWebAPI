using Moq;
using Repositories.Models.Profiles;
using Repositories.Profiles;
using Repositories.Profiles.Interfaces;

namespace UnitTests.Repositories.Profiles
{
    [TestClass]
    public class PorfileRespositoryProfilesGetUnitTests
    {
        const string ExceptionErrorMessage = "One or more errors occurred. (Exception of type 'System.Exception' was thrown.)";

        [TestMethod]
        public void Should_TheGetAllProfilesAsync_ReturnsAListOfProfiles() {

            var mockProfileDataSource = new Mock<IProfileDataSource>();

            var expectedProfiles = new List<ProfileDto>() {
                    new ProfileDto{ ProfileId = 1, FirstName = "Joe", LastName="Smith",
                        Addresses =
                            new List<ProfileAddressDto>(){ new ProfileAddressDto() {
                                AddressId = 10,
                                Address1 = "My Address 1",
                                Address2 = "My Address 2",
                                City = "My City",
                                StateAbrev = "NY", IsPrimary = true,
                            }}
                    },
                    new ProfileDto{ ProfileId = 2, FirstName = "Jill", LastName="Jones",
                        Addresses =
                            new List<ProfileAddressDto>(){ new ProfileAddressDto() {
                                AddressId = 11,
                                Address1 = "My Address 1",
                                Address2 = "My Address 2",
                                City = "My City",
                                StateAbrev = "NY", IsPrimary = true,
                            }}

                    },
            };

            mockProfileDataSource.Setup(x => x.GetProfilesAsync()).ReturnsAsync(expectedProfiles);

            var profileRepository = new ProfileRepository(mockProfileDataSource.Object);

            var actualResults = profileRepository.GetProfilesAsync().Result;

            Assert.AreEqual(actualResults, expectedProfiles);
        }

        [TestMethod]
        public void Should_TheGetAllProfilesAsync_ReturnsNoProfiles()
        {

            var mockProfileDataSource = new Mock<IProfileDataSource>();

            mockProfileDataSource.Setup(x => x.GetProfilesAsync()).ReturnsAsync(new List<ProfileDto>());

            var profileRepository = new ProfileRepository(mockProfileDataSource.Object);

            var actualResults = profileRepository.GetProfilesAsync().Result;

            Assert.AreEqual(actualResults.Any(), false);
        }

        [TestMethod]
        public void Should_TheGetAllProfilesAsync_ThrowsAnExeption()
        {

            var mockProfileDataSource = new Mock<IProfileDataSource>();

            mockProfileDataSource.Setup(x => x.GetProfilesAsync()).Throws<Exception>();

            var profileRepository = new ProfileRepository(mockProfileDataSource.Object);

            try
            {
                var actualResults = profileRepository.GetProfilesAsync().Result;

                Assert.Fail("Exception not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ExceptionErrorMessage, ex.Message);
            }
        }

        [TestMethod]
        public void Should_TheGetAProfileAsync_ReturnsAProfile()
        {

            var sourceProfilesList = new List<ProfileDto>() {
                    new ProfileDto{ ProfileId = 1, FirstName = "Joe", LastName="Smith", Active = false,
                        Addresses =
                            new List<ProfileAddressDto>(){ new ProfileAddressDto() {
                                AddressId = 10,
                                Address1 = "My Address 1",
                                Address2 = "My Address 2",
                                City = "My City",
                                StateAbrev = "NY", IsPrimary = true,
                                ZipCode = "54321"
                            }}
                    },
                    new ProfileDto{ ProfileId = 2, FirstName = "Jill", LastName="Jones", Active = true,
                        Addresses =
                            new List<ProfileAddressDto>(){ new ProfileAddressDto() {
                                AddressId = 11,
                                Address1 = "My Address 1",
                                Address2 = "My Address 2",
                                City = "My City",
                                StateAbrev = "NY", IsPrimary = true,
                                ZipCode = "12345",
                            }}

                    },
            };

            var expectedProfiles = new ProfileDto
            {
                ProfileId = 2,
                FirstName = "Jill",
                LastName = "Jones",
                Active = true,
                Addresses =
                            new List<ProfileAddressDto>(){ new ProfileAddressDto() {
                                AddressId = 11,
                                Address1 = "My Address 1",
                                Address2 = "My Address 2",
                                City = "My City",
                                StateAbrev = "NY", IsPrimary = true,
                                ZipCode = "12345"
                            }}
            };

            var mockProfileDataSource = new Mock<IProfileDataSource>();

            mockProfileDataSource.Setup(x => x.GetProfilesAsync()).ReturnsAsync(sourceProfilesList);

            var profileRepository = new ProfileRepository(mockProfileDataSource.Object);

            var actualResults = profileRepository.GetProfileByIdAsync(2).Result;

            Assert.AreEqual(actualResults.ProfileId, expectedProfiles.ProfileId);
            Assert.AreEqual(actualResults.FirstName, expectedProfiles.FirstName);
            Assert.AreEqual(actualResults.LastName, expectedProfiles.LastName);
            Assert.AreEqual(actualResults.Active, expectedProfiles.Active);

            {
                var (actualAddress, expectedAddress) = (actualResults.Addresses[0], expectedProfiles.Addresses[0]);

                Assert.AreEqual(actualAddress.AddressId, expectedAddress.AddressId);
                Assert.AreEqual(actualAddress.Address1, expectedAddress.Address1);
                Assert.AreEqual(actualAddress.Address2, expectedAddress.Address2);
                Assert.AreEqual(actualAddress.City, expectedAddress.City);
                Assert.AreEqual(actualAddress.StateAbrev, expectedAddress.StateAbrev);
                Assert.AreEqual(actualAddress.ZipCode, expectedAddress.ZipCode);
            }
        }

        [TestMethod]
        public void Should_TheGetAProfileAsync_ReturnsNoProfile()
        {
            var sourceProfilesList = new List<ProfileDto>() {
                    new ProfileDto{ ProfileId = 1, FirstName = "Joe", LastName="Smith",
                        Addresses =
                            new List<ProfileAddressDto>(){ new ProfileAddressDto() {
                                AddressId = 10,
                                Address1 = "My Address 1",
                                Address2 = "My Address 2",
                                City = "My City",
                                StateAbrev = "NY", IsPrimary = true,
                                ZipCode = "54321"
                            }}
                    },
                    new ProfileDto{ ProfileId = 2, FirstName = "Jill", LastName="Jones",
                        Addresses =
                            new List<ProfileAddressDto>(){ new ProfileAddressDto() {
                                AddressId = 11,
                                Address1 = "My Address 1",
                                Address2 = "My Address 2",
                                City = "My City",
                                StateAbrev = "NY", IsPrimary = true,
                                ZipCode = "12345",
                            }}

                    },
            };

            var mockProfileDataSource = new Mock<IProfileDataSource>();

            mockProfileDataSource.Setup(x => x.GetProfilesAsync()).ReturnsAsync(sourceProfilesList);

            var profileRepository = new ProfileRepository(mockProfileDataSource.Object);

            var actualResults = profileRepository.GetProfileByIdAsync(3).Result;

            Assert.IsNull(actualResults);
        }

        [TestMethod]
        public void Should_TheGetAProfileAsync_ThrowsAnException()
        {
            var mockProfileDataSource = new Mock<IProfileDataSource>();

            mockProfileDataSource.Setup(x => x.GetProfilesAsync()).Throws<Exception>();

            var profileRepository = new ProfileRepository(mockProfileDataSource.Object);

            try
            {
                var actualResults = profileRepository.GetProfileByIdAsync(3).Result;

                Assert.Fail("Exception not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ExceptionErrorMessage, ex.Message);
            }
        }
    }
}
