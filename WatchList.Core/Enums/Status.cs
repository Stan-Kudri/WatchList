using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WatchList.Core.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Status
    {
        AllStatus,
        Viewed,
        Planned,
        Look,
        Thrown,
    }
}
