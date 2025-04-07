using Models.Profiles;
using Repositories.Models.Profiles;
using Services.Profiles.DataMapper;

namespace UnitTests.Services.Profiles.DataMapper
{

    [TestClass]
    public class ProfileAddressCreatrModelDataMapperUnitTest
    {

        [TestMethod]
        public void Should_TheProfileAddressCreateModelDataMapper_ReturnsASuccessfulFromProfileAddressesModelMapToProfileAddressesCreateDTO()
        {

            List<ProfileAddressCreateModel> source = new() {
                new (){
                    Address1 = "My Address1 1",
                    Address2 = "My Address2 1",
                    City = "My City 1",
                    StateAbrev = "My StateAbrev 1",
                    ZipCode = "12345678",
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
                    AddressId = 4,
                    IsPrimary = true,
                    IsSecondary = false
                }
            };

            List<ProfileAddressCreateDto> expecting = new() {
                new (){
                    AddressName1 = "My Address1 1",
                    AddressName2 = "My Address2 1",
                    City = "My City 1",
                    StateAbreviated = "My StateAbrev 1",
                    ZipCode = "12345678",
                    IsPrimary = false,
                    IsSecondary = true
                },
                new (){
                    AddressName1 = "My Address1 2",
                    AddressName2 = "My Address2 2",
                    City = "My City 2",
                    StateAbreviated = "My StateAbrev 2",
                    ZipCode = "87654321",
                    IsPrimary = true,
                    IsSecondary = false
                }
            };

            List<ProfileAddressCreateDto> actual = source.MapDataAsProfileAddressCreateDto();

            Assert.AreEqual(expecting.Count, actual.Count);

            for (int i = 0; i < expecting.Count; i++)
            {
                Assert.AreEqual(actual[i].AddressName1, expecting[i].AddressName1);
                Assert.AreEqual(actual[i].AddressName2, expecting[i].AddressName2);
                Assert.AreEqual(actual[i].City, expecting[i].City);
                Assert.AreEqual(actual[i].StateAbreviated, expecting[i].StateAbreviated);
                Assert.AreEqual(actual[i].ZipCode, expecting[i].ZipCode);
                Assert.AreEqual(actual[i].IsPrimary, expecting[i].IsPrimary);
                Assert.AreEqual(actual[i].IsSecondary, expecting[i].IsSecondary);

            }
        }
    }
}
