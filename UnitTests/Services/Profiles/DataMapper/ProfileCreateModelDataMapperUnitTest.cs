using Models.Profiles;
using Repositories.Models.Profiles;
using Services.Profiles.DataMapper;

namespace UnitTests.Services.Profiles.DataMapper
{
    [TestClass]
    public class ProfileCreateModelDataMapperUnitTest
    {

        [TestMethod]
        public void Should_TheProfileModelDataMapper_ReturnsASuccessfulProfileModelMapFromAProfileAddressDTO()
        {

            List<ProfileAddressCreateDto> expectedAddresses1 = new(){
                new (){
                    Address1 = "My Address1 1",
                    Address2 = "My Address2 1",
                    City = "My City 1",
                    StateAbrev = "My StateAbrev 1",
                    ZipCode = "12345678",
                    IsPrimary = false,
                    IsSecondary = true
                },
                new (){
                    Address1 = "My Address1 2",
                    Address2 = "My Address2 2",
                    City = "My City 2",
                    StateAbrev = "My StateAbrev 2",
                    ZipCode = "87654321",
                    IsPrimary = true,
                    IsSecondary = false
                }
            };

            ProfileCreateModel source = new() {
                FirstName = "Joe",
                LastName = "Smith",
                Active = true,
                Addresses = new List<ProfileAddressCreateModel>{
                    new (){
                        AddressName1 = "My Address1 1",
                        AddressName2 = "My Address2 1",
                        City = "My City 1",
                        StateAbreviation = "My StateAbrev 1",
                        ZipCode = "12345678",
                        IsPrimary = false,
                        IsSecondary = true
                    },
                    new (){
                        AddressName1 = "My Address1 2",
                        AddressName2 = "My Address2 2",
                        City = "My City 2",
                        StateAbreviation = "My StateAbrev 2",
                        ZipCode = "87654321",
                        IsPrimary = true,
                        IsSecondary = false
                    }

                }
            };

            ProfileCreateDto expecting =
                new() {
                    FirstName = "Joe",
                    LastName = "Smith",
                    Active = true,
                    Addresses = expectedAddresses1
                };

            ProfileCreateDto actual = source.MapDataAsProfileCreateDto();

            Assert.AreEqual(actual.FirstName, expecting.FirstName);
            Assert.AreEqual(actual.LastName, expecting.LastName);
            Assert.AreEqual(actual.Active, expecting.Active);

            for (int i = 0; i < expecting.Addresses.Count; i++)
            {

                var (actualAddress, expectingAddress) = (actual.Addresses[i], expecting.Addresses[i]);

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
