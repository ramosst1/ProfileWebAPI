using Utilities.Converters.JsonObjectConverter;

namespace UnitTests.Utilities.Converters.JsonObjectConverter
{
    [TestClass]
    public class JsonObjectConverterUnitTest
    {

        [TestMethod]
        public void Should_TheJsonObjectConvertToJson_ReturnsASuccessfulJsonString()
        {

            TestClassModel source = new()
            {
                Id = 1,
                Name = "test",
            };

            string expected = "{\"Id\":1,\"Name\":\"test\"}";

            var actual = JsonConverter.Convert(source);

            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void Should_TheJsonObjectConvertToJson_ReturnsASuccessfulJsonStringList()
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

            var actual = JsonConverter.Convert(sources);

            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void Should_TheJsonObjectConverterObject_ReturnsASuccessfulObject()
        {

            string source = "{\"Id\":1,\"Name\":\"test\"}";

            TestClassModel expected = new()
            {
                Id = 1,
                Name = "test",
            };

            var actual = JsonConverter.Convert<TestClassModel>(source);

            Assert.AreEqual(actual.Id, 1);
            Assert.AreEqual(actual.Name, "test");
        }

        [TestMethod]
        public void Should_TheJsonObjectConverterObject_ReturnsASuccessfulObjectList()
        {

            string source = "[{\"Id\":1,\"Name\":\"test1\"},{\"Id\":2,\"Name\":\"test2\"}]";

            var expecting = new List<TestClassModel>() {
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

            var actual = JsonConverter.Convert<List<TestClassModel>>(source);

            Assert.AreEqual(actual.Count, 2);
            Assert.AreEqual(actual[0].Id, 1);
            Assert.AreEqual(actual[0].Name, "test1");
            Assert.AreEqual(actual[1].Id, 2);
            Assert.AreEqual(actual[1].Name, "test2");
        }
    }

    public class TestClassModel
    {

        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
    }

}
