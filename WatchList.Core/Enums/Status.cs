using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WatchList.Core.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Status
    {
        /// <summary>
        /// Any cinema status.
        /// </summary>
        AllStatus,

        /// <summary>
        /// Status => Viewed.
        /// </summary>
        Viewed,

        /// <summary>
        /// Status => Planned.
        /// </summary>
        Planned,

        /// <summary>
        /// Status => Look.
        /// </summary>
        Look,

        /// <summary>
        /// Status => Thrown.
        /// </summary>
        Thrown,
    }
}
