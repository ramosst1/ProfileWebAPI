using Models.Profiles;
using Repositories.Models.Profiles;
using Services.Profiles.DataMapper;

namespace UnitTests.Services.Profiles.DataMapper
{
    class ProfileUpdateModelDataMapperUnitTest
    {

        [TestMethod]
        public void Should_TheProfileUpdateModelDataMapper_ReturnsASuccessfulProfileUpdateModelMapFromAProfileUpdateDTO()
        {

            List<ProfileAddressUpdateDto> expectedAddresses1 = new(){
                new (){
                    Address1 = "My Address1 1",
                    Address2 = "My Address2 1",
                    City = "My City 1",
                    StateAbrev = "My StateAbrev 1",
                    ZipCode = "12345678",
                    ProfileId = 1,
                    AddressId = 2,
                    IsPrimary = false,
                    IsSecondary = true
                },
                new (){
                    Address1 = "My Address1 2",
                    Address2 = "My Address2 2",
                    City = "My City 2",
                    StateAbrev = "My StateAbrev 2",
                    ZipCode = "87654321",
                    ProfileId = 3,
                    AddressId = 4,
                    IsPrimary = true,
                    IsSecondary = false
                }
            };

            ProfileUpdateModel source = new() {
                    ProfileId = 1,
                    FirstName = "Joe",
                    LastName = "Smith",
                    Active = true,
                    Addresses = new List<ProfileAddressUpdateModel>{
                        new (){
                            AddressName1 = "My Address1 1",
                            AddressName2 = "My Address2 1",
                            City = "My City 1",
                            StateAbreviation = "My StateAbrev 1",
                            ZipCode = "12345678",
                            ProfileId = 1,
                            AddressId = 2,
                            IsPrimary = false,
                            IsSecondary = true
                        },
                        new (){
                            AddressName1 = "My Address1 2",
                            AddressName2 = "My Address2 2",
                            City = "My City 2",
                            StateAbreviation = "My StateAbrev 2",
                            ZipCode = "87654321",
                            ProfileId = 3,
                            AddressId = 4,
                            IsPrimary = true,
                            IsSecondary = false
                        }
                    }
            };

            ProfileUpdateDto expecting = new() {
                    ProfileId = 1,
                    FirstName = "Joe",
                    LastName = "Smith",
                    Active = true,
                    Addresses = expectedAddresses1
            };

            ProfileUpdateDto actual = source.MapDataAsProfileUpdateDto();

            Assert.AreEqual(actual.ProfileId, expecting.ProfileId);
            Assert.AreEqual(actual.FirstName, expecting.FirstName);
            Assert.AreEqual(actual.LastName, expecting.LastName);
            Assert.AreEqual(actual.Active, expecting.Active);

            for (int i = 0; i < expecting.Addresses.Count(); i++)
            {

                var (actualAddress, expectingAddress) = (actual.Addresses[i], expecting.Addresses[i]);

                Assert.AreEqual(actualAddress.Address1, expectingAddress.Address1);
                Assert.AreEqual(actualAddress.Address2, expectingAddress.Address2);
                Assert.AreEqual(actualAddress.City, expectingAddress.City);
                Assert.AreEqual(actualAddress.StateAbrev, expectingAddress.StateAbrev);
                Assert.AreEqual(actualAddress.ZipCode, expectingAddress.ZipCode);
                Assert.AreEqual(actualAddress.ProfileId, expectingAddress.ProfileId);
                Assert.AreEqual(actualAddress.AddressId, expectingAddress.AddressId);
                Assert.AreEqual(actualAddress.IsPrimary, expectingAddress.IsPrimary);
                Assert.AreEqual(actualAddress.IsSecondary, expectingAddress.IsSecondary);
            }
        }

    }
}
