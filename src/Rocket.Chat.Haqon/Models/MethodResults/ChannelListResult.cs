using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rocket.Chat.Haqon.Models.MethodResults
{
    public class ChannelListResult
    {
        public List<Channel> Channels { get; set; }
    }

    public class Channel
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}