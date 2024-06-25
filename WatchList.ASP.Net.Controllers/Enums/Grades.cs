using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WatchList.ASP.Net.Controllers.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Grades
    {
        AnyGrade,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten
    }
}
