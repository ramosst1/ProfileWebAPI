using Repositories.Models.Profiles;
using Repositories.Models.Profiles.DataMapperExtensions;

namespace UnitTests.Repositories.Profiles.DataMapperExtensions
{
    [TestClass]
    public class ProfileUpdateDtoDataMapperUnitTest
    {
        [TestMethod]
        public void Should_TheProfileUpdateDtoDataMapper_ReturnsASuccessfulProfileDtoMapFromAProfileWithAddressesDTO()
        {

            ProfileUpdateDto source = new()
            {
                FirstName = "Joe",
                LastName = "Smith",
                Active = true,
                Addresses = new List<ProfileAddressUpdateDto>{
                    new (){
                        AddressId=1,
                        Address1 = "My Address1 1",
                        Address2 = "My Address2 1",
                        City = "My City 1",
                        StateAbrev = "My StateAbrev 1",
                        ZipCode = "12345678",
                        IsPrimary = false,
                        IsSecondary = true
                    },
                    new (){
                        AddressId = 2,
                        Address1 = "My Address1 2",
                        Address2 = "My Address2 2",
                        City = "My City 2",
                        StateAbrev = "My StateAbrev 2",
                        ZipCode = "87654321",
                        IsPrimary = true,
                        IsSecondary = false
                    }

                }
            };

            List<ProfileAddressDto> expectedAddresses1 = new(){
                new (){
                    AddressId = 1,
                    Address1 = "My Address1 1",
                    Address2 = "My Address2 1",
                    City = "My City 1",
                    StateAbrev = "My StateAbrev 1",
                    ZipCode = "12345678",
                    IsPrimary = false,
                    IsSecondary = true
                },
                new (){
                    AddressId = 2,
                    Address1 = "My Address1 2",
                    Address2 = "My Address2 2",
                    City = "My City 2",
                    StateAbrev = "My StateAbrev 2",
                    ZipCode = "87654321",
                    IsPrimary = true,
                    IsSecondary = false
                }
            };

            ProfileDto expecting =
                new()
                {
                    ProfileId = 1,
                    FirstName = "Joe",
                    LastName = "Smith",
                    Active = true,
                    Addresses = expectedAddresses1
                };

            ProfileDto actual = source.MapDataAsProfileDto();

            Assert.AreEqual(actual.ProfileId, expecting.ProfileId);
            Assert.AreEqual(actual.FirstName, expecting.FirstName);
            Assert.AreEqual(actual.LastName, expecting.LastName);
            Assert.AreEqual(actual.Active, expecting.Active);

            for (int i = 0; i < expecting.Addresses.Count; i++)
            {

                var (actualAddress, expectingAddress) = (actual.Addresses[i], expecting.Addresses[i]);

                Assert.AreEqual(actualAddress.AddressId, expectingAddress.AddressId);
                Assert.AreEqual(actualAddress.Address1, expectingAddress.Address1);
                Assert.AreEqual(actualAddress.Address2, expectingAddress.Address2);
                Assert.AreEqual(actualAddress.City, expectingAddress.City);
                Assert.AreEqual(actualAddress.StateAbrev, expectingAddress.StateAbrev);
                Assert.AreEqual(actualAddress.ZipCode, expectingAddress.ZipCode);
                Assert.AreEqual(actualAddress.IsPrimary, expectingAddress.IsPrimary);
                Assert.AreEqual(actualAddress.IsSecondary, expectingAddress.IsSecondary);
            }
        }
    }
}
