using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using OtpNet;
using Rocket.Chat.Haqon.Interfaces;

namespace Rocket.Chat.Haqon.Models.LoginOptions
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class ResumeLoginOption : ILoginOption
    {
        private Totp totpSeed;
        private string totpToken;

        /// <summary>
        /// Active login token given from a successful, previous login.
        /// </summary>
        public string Token { get; set; }
        
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