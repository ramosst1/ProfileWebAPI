using Models.Profiles;
using Repositories.Models.Profiles;
using Services.Profiles.DataMapper;

namespace UnitTests.Services.Profiles.DataMapper
{
    [TestClass]
    public class ProfileModelDataMapperUnitTest
    {

        [TestMethod]
        public void Should_TheProfileModelDataMapper_ReturnsASuccessfulProfileModelMapFromAProfileDTO()
        {

            List<ProfileAddressDto> expectedAddresses1 = new (){
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

            List<ProfileAddressDto> expectedAddresses2 = new() {
                new (){
                    AddressName1 = "My Address1 3",
                    AddressName2 = "My Address2 3",
                    City = "My City 4",
                    StateAbreviated = "My StateAbrev 3",
                    ZipCode = "12345678",
                    ProfileId = 5,
                    AddressId = 6,
                    IsPrimary = false,
                    IsSecondary = true
                },
                new (){
                    AddressName1 = "My Address1 4",
                    AddressName2 = "My Address2 4",
                    City = "My City 4",
                    StateAbreviated = "My StateAbrev 4",
                    ZipCode = "87654321",
                    ProfileId = 6,
                    AddressId = 7,
                    IsPrimary = false,
                    IsSecondary = true
                }
            };

            List<ProfileModel> source = new() {
                new (){
                    ProfileId = 1,
                    FirstName = "Joe",
                    LastName = "Smith", 
                    Active = true,
                    Addresses = new List<ProfileAddressModel>{
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
                },
                new (){
                    ProfileId = 2,
                    FirstName = "Mary",
                    LastName = "Johnson",
                    Active = true,
                    Addresses = new List<ProfileAddressModel>
                    {
                        new (){
                            Address1 = "My Address1 3",
                            Address2 = "My Address2 3",
                            City = "My City 4",
                            StateAbrev = "My StateAbrev 3",
                            ZipCode = "12345678",
                            ProfileId = 5,
                            AddressId = 6,
                            IsPrimary = false,
                            IsSecondary = true
                        },
                        new (){
                            Address1 = "My Address1 4",
                            Address2 = "My Address2 4",
                            City = "My City 4",
                            StateAbrev = "My StateAbrev 4",
                            ZipCode = "87654321",
                            ProfileId = 6,
                            AddressId = 7,
                            IsPrimary = false,
                            IsSecondary = true
                        }
                    }
                }
            };

            List<ProfileDto> expecting = new() {
                new (){
                    ProfileId = 1,
                    FirstName = "Joe",
                    LastName = "Smith",
                    Active = true,
                    Addresses = expectedAddresses1
                },
                new (){
                    ProfileId = 2,
                    FirstName = "Mary",
                    LastName = "Johnson",
                    Active = true,
                    Addresses = expectedAddresses2
                }
            };

            List<ProfileDto> actual = source.MapData();

            Assert.AreEqual(expecting.Count, actual.Count);

            for (int i = 0; i < expecting.Count; i++)
            {
                Assert.AreEqual(actual[i].ProfileId, expecting[i].ProfileId);
                Assert.AreEqual(actual[i].FirstName, expecting[i].FirstName);
                Assert.AreEqual(actual[i].LastName, expecting[i].LastName);
                Assert.AreEqual(actual[i].Active, expecting[i].Active);

                for (int j = 0; j < expecting.Count; j++) {
                    Assert.AreEqual(actual[i].Addresses[j].AddressName1, expecting[i].Addresses[j].AddressName1);
                    Assert.AreEqual(actual[i].Addresses[j].AddressName2, expecting[i].Addresses[j].AddressName2);
                    Assert.AreEqual(actual[i].Addresses[j].City, expecting[i].Addresses[j].City);
                    Assert.AreEqual(actual[i].Addresses[j].StateAbreviated, expecting[i].Addresses[j].StateAbreviated);
                    Assert.AreEqual(actual[i].Addresses[j].ZipCode, expecting[i].Addresses[j].ZipCode);
                    Assert.AreEqual(actual[i].Addresses[j].ProfileId, expecting[i].Addresses[j].ProfileId);
                    Assert.AreEqual(actual[i].Addresses[j].AddressId, expecting[i].Addresses[j].AddressId);
                    Assert.AreEqual(actual[i].Addresses[j].IsPrimary, expecting[i].Addresses[j].IsPrimary);
                    Assert.AreEqual(actual[i].Addresses[j].IsSecondary, expecting[i].Addresses[j].IsSecondary);
                }
                 
            }

        }
    }
}
