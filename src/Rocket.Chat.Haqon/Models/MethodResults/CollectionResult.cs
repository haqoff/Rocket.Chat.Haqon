using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Rocket.Chat.Haqon.Models.MethodResults
{
    public class CollectionResult
    {
        [JsonProperty(PropertyName = "collection")]
        public string Name { get; set; }

        public string Id { get; set; }

        public JObject Fields { get; set; }
    }
}