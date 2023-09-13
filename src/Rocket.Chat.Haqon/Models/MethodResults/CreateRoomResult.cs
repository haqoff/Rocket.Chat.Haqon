using Newtonsoft.Json;

namespace Rocket.Chat.Haqon.Models.MethodResults
{
    public class CreateRoomResult
    {
        [JsonProperty(PropertyName = "rid")]
        public string RoomId { get; set; }
    }
}