using Newtonsoft.Json.Linq;

namespace Rocket.Chat.Haqon.Models
{
    public delegate void DataReceived(string type, JObject data);

    public delegate void MessageReceived(RocketMessage rocketMessage);

    public delegate void DdpReconnect();
}