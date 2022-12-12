using System.Text.Json;
using System.Text.Json.Serialization;
using Core.Model.Item;

namespace Core.Repository.DbContex
{
    public class StatusCinemaJsonConverter : JsonConverter<StatusCinema>
    {
        public override StatusCinema? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return null;

            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException();

            var name = reader.GetString() ?? throw new JsonException("Status name should be not null");

            if (!StatusCinema.TryFromName(name, out var value))
                throw new JsonException("Invalid Status name");

            return value;
        }

        public override void Write(Utf8JsonWriter writer, StatusCinema? value, JsonSerializerOptions? options = null)
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
