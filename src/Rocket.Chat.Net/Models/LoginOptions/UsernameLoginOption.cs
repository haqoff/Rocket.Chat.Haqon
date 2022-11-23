﻿namespace Rocket.Chat.Net.Models.LoginOptions
{
    using System.Diagnostics.CodeAnalysis;
    using OtpNet;
    using Rocket.Chat.Net.Interfaces;

    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class UsernameLoginOption : ILoginOption
    {
        private Totp totpSeed;
        private string totpToken;

        /// <summary>
        /// Username of the user to login as. This should not be a email address. 
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Plaintext password of the user. 
        /// </summary>
        public string Password { get; set; }

        public Totp TOTPSeed
        {
            get => totpSeed;
            set => totpSeed = value;
        }

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