using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WatchList.Core.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Grades
    {
        /// <summary>
        /// All grade.
        /// </summary>
        AnyGrade,

        /// <summary>
        /// Grade = 1.
        /// </summary>
        One,

        /// <summary>
        /// Grade = 2.
        /// </summary>
        Two,

        /// <summary>
        /// Grade = 3.
        /// </summary>
        Three,

        /// <summary>
        /// Grade = 4.
        /// </summary>
        Four,

        /// <summary>
        /// Grade = 5.
        /// </summary>
        Five,

        /// <summary>
        /// Grade = 6.
        /// </summary>
        Six,

        /// <summary>
        /// Grade = 7.
        /// </summary>
        Seven,

        /// <summary>
        /// Grade = 8.
        /// </summary>
        Eight,

        /// <summary>
        /// Grade = 9.
        /// </summary>
        Nine,

        /// <summary>
        /// Grade = 10.
        /// </summary>
        Ten,
    }
}
