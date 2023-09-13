using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Rocket.Chat.Haqon.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RoomType
    {
        [EnumMember(Value = "p")] PrivateGroup = 'p',
        [EnumMember(Value = "g")] PrivateGroup2 = 'g',
        [EnumMember(Value = "d")] DirectMessage = 'd',
        [EnumMember(Value = "c")] Channel = 'c'
    }
}