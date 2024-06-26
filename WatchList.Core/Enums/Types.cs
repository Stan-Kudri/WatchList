using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WatchList.Core.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Types
    {
        /// <summary>
        /// Any type of cinema.
        /// </summary>
        AllType,

        /// <summary>
        /// Type => Movie.
        /// </summary>
        Movie,

        /// <summary>
        /// Type => Series.
        /// </summary>
        Series,

        /// <summary>
        /// Type => Anime.
        /// </summary>
        Anime,

        /// <summary>
        /// Type => Cartoon.
        /// </summary>
        Cartoon,
    }
}
