using Models.States;
using Repositories.Models.States;
using Services.States.DataMapper;

namespace UnitTests.Services.States.DataMapper
{
    [TestClass]
    public class StateModelDataMapperUnitTest
    {
        [TestMethod]
        public void Should_TheStateModelDataMapper_ReturnsASuccessfulStateModelMapFromAStateDTO() {

            List<StateDto> source = new () { 
                new () { StateAbrev = "NY", StateName = "New York" },
                new () { StateAbrev = "CT", StateName = "Conneticult" }
            };

            List<StateModel> expecting = new() {
                new () { StateAbreviation = "NY", StateName = "New York" },
                new () { StateAbreviation = "CT", StateName = "Conneticult" }
            };

            List<StateModel> actual = source.MapDataAsStateModel();

            Assert.AreEqual(expecting.Count, actual.Count);

            for (int i = 0; i < expecting.Count; i++) {
                Assert.AreEqual(actual[i].StateAbreviation, expecting[i].StateAbreviation);
                Assert.AreEqual(actual[i].StateName, expecting[i].StateName);
            }
        }
    }
}
