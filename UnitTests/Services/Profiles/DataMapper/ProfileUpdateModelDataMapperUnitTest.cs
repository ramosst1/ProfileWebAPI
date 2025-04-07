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
                    AddressName1 = "My Address1 1",
                    AddressName2 = "My Address2 1",
                    City = "My City 1",
                    StateAbreviated = "My StateAbrev 1",
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
                    StateAbreviated = "My StateAbrev 2",
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
                Assert.AreEqual(actual.Addresses[i].AddressName1, expecting.Addresses[i].AddressName1);
                Assert.AreEqual(actual.Addresses[i].AddressName2, expecting.Addresses[i].AddressName2);
                Assert.AreEqual(actual.Addresses[i].City, expecting.Addresses[i].City);
                Assert.AreEqual(actual.Addresses[i].StateAbreviated, expecting.Addresses[i].StateAbreviated);
                Assert.AreEqual(actual.Addresses[i].ZipCode, expecting.Addresses[i].ZipCode);
                Assert.AreEqual(actual.Addresses[i].ProfileId, expecting.Addresses[i].ProfileId);
                Assert.AreEqual(actual.Addresses[i].AddressId, expecting.Addresses[i].AddressId);
                Assert.AreEqual(actual.Addresses[i].IsPrimary, expecting.Addresses[i].IsPrimary);
                Assert.AreEqual(actual.Addresses[i].IsSecondary, expecting.Addresses[i].IsSecondary);
            }
        }

    }
}
