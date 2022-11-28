using System.Text.Json;
using System.Text.Json.Serialization;
using Ardalis.SmartEnum;
using ListWatchedMoviesAndSeries.Models.Item;

namespace Core.Repository.JSONConverter
{
    public class TypeCinemaJsonConverter : JsonConverter<TypeCinema>
    {
        private const string NameOfName = "Name";

        public override TypeCinema? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return null;

            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();

            SkipPropertyName(ref reader, NameOfName);

            reader.Read();
            var name = reader.GetString() ?? throw new InvalidOperationException("Name property in class TypeCinema not null");

            if (!TypeCinema.TryFromName(name, out var value))
                throw new InvalidOperationException("Erroneous value");

            if (!Sequel(name, out var sequel))
                throw new InvalidOperationException("Erroneous value sequel");

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
            writer.WriteEndObject();
        }

        private void SkipPropertyName(ref Utf8JsonReader reader, string nameofValue)
        {
            if (!reader.Read())
                throw new JsonException();
            if (reader.TokenType != JsonTokenType.PropertyName)
                throw new JsonException();

            string? propertyName = reader.GetString();
            if (propertyName != nameofValue)
                throw new JsonException();
        }

        private bool Sequel(string name, out string sequel)
        {
            sequel = string.Empty;
            foreach (var item in SmartEnum<TypeCinema>.List)
            {
                if (item.Name == name)
                {
                    name = item.TypeSequel;
                    return true;
                }
            }
            return false;
        }
    }
}
