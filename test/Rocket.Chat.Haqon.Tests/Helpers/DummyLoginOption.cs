using Rocket.Chat.Haqon.Interfaces;

namespace Rocket.Chat.Net.Tests.Helpers
{
    using OtpNet;

    public class DummyLoginOption : ILoginOption
    {
        public Totp TOTPSeed
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
        public string TOTPToken
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
    }
}