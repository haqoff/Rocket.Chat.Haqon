using Newtonsoft.Json;

namespace Rocket.Chat.Haqon.Models
{
    public class User
    {
        /// <summary>
        /// User Id
        /// </summary>
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        public override string ToString()
        {
            return $"{Username} ({Id})";
        }
    }
}