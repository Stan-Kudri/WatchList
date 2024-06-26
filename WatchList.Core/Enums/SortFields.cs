using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WatchList.Core.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortFields
    {
        /// <summary>
        /// Sort field by Title.
        /// </summary>
        Title,

        /// <summary>
        /// Sort field by Sequel.
        /// </summary>
        Sequel,

        /// <summary>
        /// Sort field by Status.
        /// </summary>
        Status,

        /// <summary>
        /// Sort field by Date.
        /// </summary>
        Date,

        /// <summary>
        /// Sort field by Grade.
        /// </summary>
        Grade,

        /// <summary>
        /// Sort field by Type.
        /// </summary>
        Type,
    }
}
