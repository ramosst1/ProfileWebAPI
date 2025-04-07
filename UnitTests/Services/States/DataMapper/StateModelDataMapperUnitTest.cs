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
                new () { StateAbrev = "NY", StateFullName = "New York" },
                new () { StateAbrev = "CT", StateFullName = "Conneticult" }
            };

            List<StateModel> expecting = new() {
                new () { StateAbrev = "NY", StateName = "New York" },
                new () { StateAbrev = "CT", StateName = "Conneticult" }
            };

            List<StateModel> actual = source.MapData();

            Assert.AreEqual(expecting.Count, actual.Count);

            for (int i = 0; i < expecting.Count; i++) {
                Assert.AreEqual(actual[i].StateAbrev, expecting[i].StateAbrev);
                Assert.AreEqual(actual[i].StateName, expecting[i].StateName);
            }
        }
    }
}
