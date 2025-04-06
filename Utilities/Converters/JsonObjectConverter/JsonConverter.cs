namespace Utilities.Converters.JsonObjectConverter
{
    public sealed class JsonConverter
    {
        private JsonConverter() { }

        public static string Convert<TObject>(TObject source)
        {
            return System.Text.Json.JsonSerializer.Serialize(source);
        }

        public static TObject Convert<TObject>(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<TObject>(json);
        }
    }
}
