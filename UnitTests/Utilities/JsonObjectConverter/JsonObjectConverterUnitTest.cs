using Utilities.Converters.JsonObjectConverter;

namespace UnitTests.Utilities.JsonObjectConverter
{
    [TestClass]
    public class JsonObjectConverterUnitTest
    {

        [TestMethod]
        public void Should_TheJsonObjectConverter_ReturnsASuccessfulJson()
        {

            TestClassModel source = new()
            {
                Id = 1,
                Name = "test",
            };

            string expected = "{\"Id\":1,\"Name\":\"test\"}";


            var actual = JsonConverter.Convert<TestClassModel>(source);

            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void Should_TheJsonObjectConverter_ReturnsASuccessfulJsonList()
        {

            var sources = new List<TestClassModel>() {
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

            string expected = "[{\"Id\":1,\"Name\":\"test1\"},{\"Id\":2,\"Name\":\"test2\"}]";

            var actual = JsonConverter.Convert<List<TestClassModel>>(sources);

            Assert.AreEqual(actual, expected);

        }


    }

    public class TestClassModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
    }

}
