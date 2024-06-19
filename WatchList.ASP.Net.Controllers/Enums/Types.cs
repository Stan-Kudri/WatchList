using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WatchList.ASP.Net.Controllers.Enums
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
