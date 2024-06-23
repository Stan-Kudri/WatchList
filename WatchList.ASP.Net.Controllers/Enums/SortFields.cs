using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WatchList.ASP.Net.Controllers.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortFields
    {
        Title,
        Sequel,
        Status,
        Data,
        Grade,
        Type
    }
}
