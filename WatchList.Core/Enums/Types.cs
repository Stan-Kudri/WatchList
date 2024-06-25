using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WatchList.Core.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Types
    {
        AllType,
        Movie,
        Series,
        Anime,
        Cartoon,
    }
}
