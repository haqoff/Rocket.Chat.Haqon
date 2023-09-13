﻿using System;
using Newtonsoft.Json;
using Rocket.Chat.Haqon.JsonConverters;

namespace Rocket.Chat.Haqon.Models.MethodResults
{
    public class LoginResult
    {
        [JsonProperty(PropertyName = "id")]
        public string UserId { get; set; }

        public string Token { get; set; }

        [JsonConverter(typeof(MeteorDateConverter))]
        public DateTime TokenExpires { get; set; }
    }
}