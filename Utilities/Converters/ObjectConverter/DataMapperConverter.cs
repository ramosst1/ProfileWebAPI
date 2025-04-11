namespace Utilities.Converters.ObjectConverter
{
    public sealed class DataMapperConverter
    {
        private DataMapperConverter(){}

        public static TTarget Convert<TSource, TTarget>(TSource source)
        {
            if (source == null) return default;

            return System.Text.Json.JsonSerializer.Deserialize<TTarget>(
                System.Text.Json.JsonSerializer.Serialize(source)
            );
        }
    }
}


