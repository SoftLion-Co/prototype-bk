using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DAL.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProjectStatusEnum
    {
        InProgress =0,
        Completed =1,
        OnHold = 2,
        Canceled =3
    }
}
