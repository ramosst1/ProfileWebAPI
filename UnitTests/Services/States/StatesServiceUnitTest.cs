using Moq;
using Models.States;
using Services.States;
using Repositories.Models.States;
using Repositories.States.Interfaces;

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
                new (){ StateName = "New York", StateAbreviation = "NY" },
                new (){ StateName = "New Jersey", StateAbreviation = "NJ" },
                new (){ StateName = "Connecticut", StateAbreviation = "CT" },
                new (){ StateName = "Main", StateAbreviation = "ME" }
            };

            var actualStates = new List<StateDto>() {
                new (){ StateName = "New York", StateAbrev = "NY" },
                new (){ StateName = "New Jersey", StateAbrev = "NJ" },
                new (){ StateName = "Connecticut", StateAbrev = "CT" },
                new (){ StateName = "Main", StateAbrev = "ME" }
            };

            var statesRepository = new Mock<IStatesRepository>();

            var statesServices = new StatesService(statesRepository.Object);

            statesRepository.Setup(x => x.GetAllStatesAsync()).ReturnsAsync(actualStates);

            var actualResults = statesServices.GetAllStatesAsync().Result;

            Assert.AreEqual(actualResults.Success, true);
            Assert.AreEqual(actualResults.ErrorMessages.Any(), false);

            for (var i = 0; i < actualStates.Count; i++)
            {
                Assert.AreEqual(expectedStates[i].StateName, actualStates[i].StateName);
                Assert.AreEqual(expectedStates[i].StateAbreviation, actualStates[i].StateAbrev);
            }
        }

        [TestMethod]
        public void Should_TheGetAllStatesAsync_ReturnsNoStates()
        {
            var mockStatesRepository = new Mock<IStatesRepository>();

            var mockStatesServices = new StatesService(mockStatesRepository.Object);

            mockStatesRepository.Setup(x => x.GetAllStatesAsync()).ReturnsAsync(new List<StateDto>());

            var actualResults = mockStatesServices.GetAllStatesAsync().Result;


            Assert.AreEqual(actualResults.ErrorMessages.Any(), false);
            Assert.AreEqual(actualResults.Success, true);
            Assert.AreEqual(actualResults.data.Any(), false);

        }

        [TestMethod]
        public void Should_TheGetAllStatesAsync_ReturnsNoStatesBecauseExceptionThrown()
        {
            var mockStatesRepository = new Mock<IStatesRepository>();

            var mockStatesServices = new StatesService(mockStatesRepository.Object);

            mockStatesRepository.Setup(x => x.GetAllStatesAsync())
                .Throws<Exception>();

            var actualResults = mockStatesServices.GetAllStatesAsync().Result;

            Assert.AreEqual(actualResults.Success, false);
            Assert.AreEqual(actualResults.data, null);
            Assert.AreEqual(actualResults.ErrorMessages[0].InternalMessage, InternalErrorMessage);
            Assert.AreEqual(actualResults.ErrorMessages[0].ExternalMessage, ExternalErrorMessage);
        }

    }
}