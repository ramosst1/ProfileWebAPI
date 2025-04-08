using Microsoft.AspNetCore.Hosting.Server.Features;
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
                        AddressName1 = "My Address 1",
                        AddressName2 = "My Address 2",
                        City = "My City",
                        StateAbreviation = "CT", IsPrimary = true,
                        ZipCode = "54321"
                    }}
            };

            var mockProfileRepository = new Mock<IProfileRepository>();

            mockProfileRepository.Setup(x => x.CreateProfileAsync(It.IsAny<ProfileCreateDto>())).ReturnsAsync(profileDtoCreateOutput);

            var profileService = new ProfileService(mockProfileRepository.Object);

            var actualResults = profileService.CreateProfileAsync(profileToCreate).Result;

            Assert.AreEqual(actualResults.Success, true);
            Assert.AreEqual(actualResults.ErrorMessages.Any(), false);

            Assert.AreEqual(actualResults.data.ProfileId, 1);
            Assert.AreEqual(actualResults.data.FirstName, profileToCreate.FirstName);
            Assert.AreEqual(actualResults.data.LastName, profileToCreate.LastName);
            Assert.AreEqual(actualResults.data.Active, profileToCreate.Active);

            { 
                var (actualaddresses, expectedAddresses) = (actualResults.data.Addresses.FirstOrDefault(), profileToCreate.Addresses[0]);

                Assert.AreEqual(actualaddresses.AddressId, 10);
                Assert.AreEqual(actualaddresses.AddressName1, expectedAddresses.AddressName1);
                Assert.AreEqual(actualaddresses.AddressName2, expectedAddresses.AddressName2);
                Assert.AreEqual(actualaddresses.City, expectedAddresses.City);
                Assert.AreEqual(actualaddresses.StateAbreviation, expectedAddresses.StateAbreviation);
                Assert.AreEqual(actualaddresses.ZipCode, expectedAddresses.ZipCode);
            }
        }

        [TestMethod]
        public void Should_TheCreateAProfileAsync_ThrowsAnException()
        {

            var mockProfileRepository = new Mock<IProfileRepository>();

            mockProfileRepository.Setup(x => x.CreateProfileAsync(It.IsAny<ProfileCreateDto>())).Throws<Exception>();

            var profileService = new ProfileService(mockProfileRepository.Object);

            var actualResults = profileService.CreateProfileAsync(new ProfileCreateModel()).Result;

            Assert.AreEqual(actualResults.Success, false);
            Assert.AreEqual(actualResults.data, null);
            Assert.AreEqual(actualResults.ErrorMessages[0].InternalMessage, InternalErrorMessage);
            Assert.AreEqual(actualResults.ErrorMessages[0].ExternalMessage, ExternalErrorMessage);
        }

    }
}
