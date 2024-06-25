using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WatchList.Core.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortFields
    {
        Title,
        Sequel,
        Status,
        Date,
        Grade,
        Type
    }
}
