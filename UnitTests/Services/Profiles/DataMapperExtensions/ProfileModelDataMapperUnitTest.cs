using Models.Profiles;
using Repositories.Models.Profiles;
using Services.Profiles.DataMapperExtensions;

namespace UnitTests.Services.Profiles.DataMapperExtensions
{
    [TestClass]
    public class ProfileModelDataMapperUnitTest
    {

        [TestMethod]
        public void Should_TheProfileModelDataMapper_ReturnsASuccessfulProfileModelMapFromAProfileDTO()
        {

            List<ProfileAddressDto> expectedAddresses1 = new (){
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

            List<ProfileAddressDto> expectedAddresses2 = new() {
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
            };

            List<ProfileModel> source = new() {
                new (){
                    ProfileId = 1,
                    FirstName = "Joe",
                    LastName = "Smith", 
                    Active = true,
                    Addresses = new List<ProfileAddressModel>{
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
                },
                new (){
                    ProfileId = 2,
                    FirstName = "Mary",
                    LastName = "Johnson",
                    Active = true,
                    Addresses = new List<ProfileAddressModel>
                    {
                        new (){
                            AddressName1 = "My Address1 3",
                            AddressName2 = "My Address2 3",
                            City = "My City 4",
                            StateAbreviation = "My StateAbrev 3",
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
                            StateAbreviation = "My StateAbrev 4",
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

            List<ProfileDto> actual = source.MapDataAsProfileDto();

            Assert.AreEqual(expecting.Count, actual.Count);

            for (int i = 0; i < expecting.Count; i++)
            {

                var (actualResults, expectingResults) = (actual[i], expecting[i]);

                Assert.AreEqual(actualResults.ProfileId, expectingResults.ProfileId);
                Assert.AreEqual(actualResults.FirstName, expectingResults.FirstName);
                Assert.AreEqual(actualResults.LastName, expectingResults.LastName);
                Assert.AreEqual(actualResults.Active, expectingResults.Active);

                for (int j = 0; j < expecting.Count; j++) {

                    var (actualAddress, expectingAddress) = (actualResults.Addresses[j], expectingResults.Addresses[j]);

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
}
