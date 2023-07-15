using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DAL.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderTypeEnum
    {
        New = 0,
        Accepted = 1,
        Rejected = 2
    }
}
