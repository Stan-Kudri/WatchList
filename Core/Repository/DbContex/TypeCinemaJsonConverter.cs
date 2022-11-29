using System.Text.Json;
using System.Text.Json.Serialization;
using ListWatchedMoviesAndSeries.Models.Item;

namespace Core.Repository.JSONConverter
{
    public class TypeCinemaJsonConverter : JsonConverter<TypeCinema>
    {
        public override TypeCinema? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return null;

            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException();

            var name = reader.GetString() ?? throw new JsonException("TypeCinema name should be not null");

            if (!TypeCinema.TryFromName(name, out var value))
                throw new JsonException("Invalid TypeCinema name");

            return value;
        }

        public override void Write(Utf8JsonWriter writer, TypeCinema? value, JsonSerializerOptions? options = null)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }
            writer.WriteStringValue(value.Name);
        }
    }
}
