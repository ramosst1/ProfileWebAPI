namespace Utilities.Converters.JsonObjectConverter
{
    public sealed class JsonConverter
    {
        private JsonConverter() { }

        public static string Convert<TObject>(TObject source)
        {

            string result = System.Text.Json.JsonSerializer.Serialize(source);

            return result;
        }
    }
}
