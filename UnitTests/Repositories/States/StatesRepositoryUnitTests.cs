﻿using Moq;
using Repositories.Models.States;
using Repositories.States;

namespace UnitTests.Repositories.States
{
    [TestClass]
    public class StatesRepositoryUnitTests
    {
        const string ExceptionErrorMessage = "One or more errors occurred. (Exception of type 'System.Exception' was thrown.)";

        [TestMethod]
        public void Should_TheGetAllStatesAsync_ReturnsAListOfStates()
        {
            var expectedStates = new List<StateDto>() {
                new StateDto{ StateFullName = "New York", StateAbrev = "NY" },
                new StateDto{ StateFullName = "New Jersey", StateAbrev = "NJ" },
                new StateDto{ StateFullName = "Connecticut", StateAbrev = "CT" },
                new StateDto{ StateFullName = "Main", StateAbrev = "ME" }
            };

            var actualStates = new List<StateDto>() {
                new StateDto{ StateFullName = "New York", StateAbrev = "NY" },
                new StateDto{ StateFullName = "New Jersey", StateAbrev = "NJ" },
                new StateDto{ StateFullName = "Connecticut", StateAbrev = "CT" },
                new StateDto{ StateFullName = "Main", StateAbrev = "ME" }
            };

            var mockStatesJsonDataSource = new Mock<IStatesDataSource>();

            mockStatesJsonDataSource.Setup(x => x.GetAllStates()).ReturnsAsync(expectedStates);

            var statesRepository = new StatesRepository(mockStatesJsonDataSource.Object);

            var actualResults = statesRepository.GetAllStatesAsync().Result;

            for (var i = 0; i < actualStates.Count; i++)
            {
                Assert.AreEqual(expectedStates[i].StateFullName, actualStates[i].StateFullName);
                Assert.AreEqual(expectedStates[i].StateAbrev, actualStates[i].StateAbrev);
            }
        }

        [TestMethod]
        public void Should_TheGetAllStatesAsync_ReturnsNoStates()
        {

            var mockStatesJsonDataSource = new Mock<IStatesDataSource>();

            mockStatesJsonDataSource.Setup(x => x.GetAllStates()).ReturnsAsync(new List<StateDto>());

            var statesRepository = new StatesRepository(mockStatesJsonDataSource.Object);

            var actualResults = statesRepository.GetAllStatesAsync().Result;

            Assert.AreEqual(false, actualResults.Any());
        }

        [TestMethod]
        public void Should_TheGetAllStatesAsync_ReturnsAnException()
        {
            var mockStatesJsonDataSource = new Mock<IStatesDataSource>();

            mockStatesJsonDataSource.Setup(x => x.GetAllStates()).Throws<Exception>();

            var statesRepository = new StatesRepository(mockStatesJsonDataSource.Object);

            try
            {
                var actualResults = statesRepository.GetAllStatesAsync().Result;

                Assert.Fail("Exception not thrown.");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ExceptionErrorMessage, ex.Message);
            }
        }
    }
}
