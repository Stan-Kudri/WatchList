using System.Text.Json;
using System.Text.Json.Serialization;
using ListWatchedMoviesAndSeries.Models.Item;

namespace Core.Repository.JSONConverter
{
    public class TypeCinemaJsonConverter : JsonConverter<TypeCinema>
    {
        private const string NameOfName = "Name";
        private const string NameOfValue = "Value";
        private const string NameOfTypeSequel = "TypeSequel";

        public override TypeCinema? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return null;

            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();

            SkipPropertyName(ref reader);
            СomparePropertyName(ref reader, NameOfName);

            reader.Read();
            var name = reader.GetString() ?? throw new InvalidOperationException("Name property in class TypeCinema not null");

            SkipPropertyName(ref reader);
            СomparePropertyName(ref reader, NameOfValue);

            reader.Read();
            if (int.TryParse(reader.GetString(), out var value))
            {
                if (value < 0)
                    throw new InvalidOperationException("Value property in class TypeCinema above zero");
            }
            else
                throw new JsonException();

            SkipPropertyName(ref reader);
            СomparePropertyName(ref reader, NameOfTypeSequel);

            reader.Read();

            var sequel = reader.GetString() ?? throw new InvalidOperationException("TypeSequel property in class TypeCinema not null");

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndObject)
                throw new JsonException();

            return new TypeCinema(name, value, sequel);
        }

        public override void Write(Utf8JsonWriter writer, TypeCinema? value, JsonSerializerOptions? options = null)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            writer.WriteStartObject();

            writer.WriteString(NameOfName, value.Name);
            writer.WriteString(NameOfValue, value.Value.ToString());
            writer.WriteString(NameOfTypeSequel, value.TypeSequel);

            writer.WriteEndObject();
        }

        private void SkipPropertyName(ref Utf8JsonReader reader)
        {
            if (!reader.Read())
                throw new JsonException();
            if (reader.TokenType != JsonTokenType.PropertyName)
                throw new JsonException();
        }

        private void СomparePropertyName(ref Utf8JsonReader reader, string nameofValue)
        {
            string? propertyName = reader.GetString();
            if (propertyName != nameofValue)
                throw new JsonException();
        }
    }
}
