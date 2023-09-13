using Rocket.Chat.Haqon.JsonConverters;

namespace Rocket.Chat.Net.Tests.Helpers
{
    using System;

    using Newtonsoft.Json;

    public class MeteorDateSerializerModel
    {
        [JsonConverter(typeof(MeteorDateConverter))]
        public DateTime? DateTime { get; set; }
    }
}