namespace Utilities.Converters.ObjectConverter
{
    public sealed class DataMapperConverter
    {
        private DataMapperConverter(){}

        public static TTarget Convert<TSource, TTarget>(TSource source)
        {
            if (source == null) return default;

            string jsonString = System.Text.Json.JsonSerializer.Serialize(source);

            TTarget? response = System.Text.Json.JsonSerializer.Deserialize<TTarget>(jsonString);

            return response;
        }
    }
}
