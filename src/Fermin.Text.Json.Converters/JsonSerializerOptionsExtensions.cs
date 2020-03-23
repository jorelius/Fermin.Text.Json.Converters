using System.Text.Json;

namespace Fermin.Text.Json.Converters
{
    public static class JsonSerializerOptionsExtensions
    {
        public static JsonSerializerOptions AddDynamicConverter(this JsonSerializerOptions options)
        {
            options.Converters.Add(new DynamicConverter());
            return options;
        }
    }
}