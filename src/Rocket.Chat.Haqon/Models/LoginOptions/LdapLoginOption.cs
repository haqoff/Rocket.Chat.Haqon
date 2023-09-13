using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using OtpNet;
using Rocket.Chat.Haqon.Interfaces;

namespace Rocket.Chat.Haqon.Models.LoginOptions
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class LdapLoginOption : IRestLoginOption
    {
        private Totp totpSeed;
        private string totpToken;

        /// <summary>
        /// Username of the user to login as. Do not include the domain in which this user resides. 
        /// </summary>
        [JsonProperty(PropertyName = "user")]
        public string Username { get; set; }

        /// <summary>
        /// Plaintext password of the user. 
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonIgnore]
        public Totp TOTPSeed
        {
            get => totpSeed;
            set => totpSeed = value;
        }

        [JsonIgnore]

        public string TOTPToken
        {
            get
            {
                if (this.totpSeed != null)
                    totpToken = totpSeed.ComputeTotp();
                return totpToken;
            }
            set
            {
                totpToken = value;
            }
        }
    }
}