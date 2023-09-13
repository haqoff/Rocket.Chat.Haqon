using Rocket.Chat.Haqon.JsonConverters;
using Rocket.Chat.Haqon.Models;

namespace Rocket.Chat.Net.Tests.Helpers
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class RocketReactionConverterModel
    {
        [JsonConverter(typeof(RocketReactionConverter))]
        public IList<Reaction> Reactions { get; set; }
    }
}