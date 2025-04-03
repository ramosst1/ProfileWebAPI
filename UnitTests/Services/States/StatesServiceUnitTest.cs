using Moq;
using Models.States;
using Repositories.States;
using Services.States;

namespace UnitTests.Services.States
{
    [TestClass]
    public class StatesServiceUnitTest
    {
        const string InternalErrorMessage = "Exception of type 'System.Exception' was thrown.";
        const string ExternalErrorMessage = "Exception of type 'System.Exception' was thrown.";

        [TestMethod]
        public void Should_TheGetAllStatesAsync_ReturnsAListOfStates()
        {
            var expectedStates = new List<StateModel>() { 
                new StateModel{ StateName = "New York", StateAbrev = "NY" },
                new StateModel{ StateName = "New Jersey", StateAbrev = "NJ" },
                new StateModel{ StateName = "Connecticut", StateAbrev = "CT" },
                new StateModel{ StateName = "Main", StateAbrev = "ME" }
            };

            var actualStates = new List<StateDto>() {
                new StateDto{ StateName = "New York", StateAbrev = "NY" },
                new StateDto{ StateName = "New Jersey", StateAbrev = "NJ" },
                new StateDto{ StateName = "Connecticut", StateAbrev = "CT" },
                new StateDto{ StateName = "Main", StateAbrev = "ME" }
            };

            var statesRepository = new Mock<IStatesRepository>();

            var statesServices = new StatesServices(statesRepository.Object);

            statesRepository.Setup(x => x.GetAllStatesAsync()).ReturnsAsync(actualStates);

            var actualResults = statesServices.GetAllStatesAsync().Result;

            Assert.AreEqual(actualResults.Success, true);
            Assert.AreEqual(actualResults.Messages.Any(), false);

            for (var i = 0; i < actualStates.Count; i++)
            {
                Assert.AreEqual(expectedStates[i].StateName, actualStates[i].StateName);
                Assert.AreEqual(expectedStates[i].StateAbrev, actualStates[i].StateAbrev);
            }
        }

        [TestMethod]
        public void Should_TheGetAllStatesAsync_ReturnsNoStates()
        {
            var statesRepository = new Mock<IStatesRepository>();

            var statesServices = new StatesServices(statesRepository.Object);

            statesRepository.Setup(x => x.GetAllStatesAsync()).ReturnsAsync(new List<StateDto>());

            var actualResults = statesServices.GetAllStatesAsync().Result;


            Assert.AreEqual(actualResults.Messages.Any(), false);
            Assert.AreEqual(actualResults.Success, true);
            Assert.AreEqual(actualResults.data.Any(), false);

        }

        [TestMethod]
        public void Should_TheGetAllStatesAsync_ReturnsNoStatesBecauseExceptionThrown()
        {
            var statesRepository = new Mock<IStatesRepository>();

            var statesServices = new StatesServices(statesRepository.Object);

            statesRepository.Setup(x => x.GetAllStatesAsync())
                .Throws<Exception>();

            var actualResults = statesServices.GetAllStatesAsync().Result;

            Assert.AreEqual(actualResults.Success, false);
            Assert.AreEqual(actualResults.data, null);
            Assert.AreEqual(actualResults.Messages[0].InternalMessage, InternalErrorMessage);
            Assert.AreEqual(actualResults.Messages[0].ExternalMessage, ExternalErrorMessage);
        }

    }
}