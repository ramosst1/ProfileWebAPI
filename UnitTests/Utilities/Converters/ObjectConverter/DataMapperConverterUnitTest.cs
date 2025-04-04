using Utilities.Converters.ObjectConverter;

namespace UnitTests.Utilities.Converters.ObjectConverter
{

    [TestClass]
    public class DataMapperConverterUnitTest
    {

        [TestMethod]
        public void Should_TheDataMapperConverter_ReturnsASuccessfulMapping()
        {
            TestClassDto source = new () {
                Id = 1,
                Name = "test",
            };

            TestClassModel expectingSource = new()
            {
                Id = 1,
                Name = "test",
            };

            TestClassModel actualResult = DataMapperConverter.Convert<TestClassDto, TestClassModel>(source);

            Assert.AreEqual(actualResult.Id, expectingSource.Id);
            Assert.AreEqual(actualResult.Name, expectingSource.Name);

        }

        [TestMethod]
        public void Should_TheDataMapperConverter_ReturnsASuccessfulMappingList()
        {

            var sources = new List<TestClassDto>() {
                new()
                    {
                        Id = 1,
                        Name = "test1",
                    },
                new()
                    {
                        Id = 2,
                        Name = "test2",
                    }
            };

            var expectingSources = new List<TestClassModel>() {
                new()
                    {
                        Id = 1,
                        Name = "test1",
                    },
                new()
                    {
                        Id = 2,
                        Name = "test2",
                    }
            };

            List<TestClassModel> actualResults = DataMapperConverter.Convert<List<TestClassDto>, List<TestClassModel>>(sources);

            Assert.AreEqual(actualResults[0].Id, expectingSources[0].Id);
            Assert.AreEqual(actualResults[0].Name, expectingSources[0].Name);

            Assert.AreEqual(actualResults[1].Id, expectingSources[1].Id);
            Assert.AreEqual(actualResults[1].Name, expectingSources[1].Name);

        }

    }

    public class TestClassModel {

        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class TestClassDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
    }

}
