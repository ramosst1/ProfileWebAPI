﻿
using Models.Profiles;
using Repositories.Models.Profiles;
using Services.Profiles.DataMapper;

namespace UnitTests.Services.Profiles.DataMapper
{
    [TestClass]
    public class ProfileAddressUpdateModelDataMapperUnitTest
    {

        [TestMethod]
        public void Should_TheProfileAddressUpdateModelDataMapper_ReturnsASuccessfulProfileUpdateModelMapFromAProfileAddressUpdateDTO()
        {

            List<ProfileAddressUpdateModel> source = new() {
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
            };

            List<ProfileAddressUpdateDto> expecting = new() {
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

            List<ProfileAddressUpdateDto> actual = source.MapDataAsProfileAddressUpdateDto();

            Assert.AreEqual(expecting.Count, actual.Count);

            for (int i = 0; i < expecting.Count; i++)
            {
                Assert.AreEqual(actual[i].Address1, expecting[i].Address1);
                Assert.AreEqual(actual[i].Address2, expecting[i].Address2);
                Assert.AreEqual(actual[i].City, expecting[i].City);
                Assert.AreEqual(actual[i].StateAbrev, expecting[i].StateAbrev);
                Assert.AreEqual(actual[i].ZipCode, expecting[i].ZipCode);
                Assert.AreEqual(actual[i].ProfileId, expecting[i].ProfileId);
                Assert.AreEqual(actual[i].AddressId, expecting[i].AddressId);
                Assert.AreEqual(actual[i].IsPrimary, expecting[i].IsPrimary);
                Assert.AreEqual(actual[i].IsSecondary, expecting[i].IsSecondary);

            }
        }

    }
}
