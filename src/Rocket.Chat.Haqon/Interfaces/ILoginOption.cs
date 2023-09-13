using OtpNet;

namespace Rocket.Chat.Haqon.Interfaces
{
    public interface ILoginOption
    {

        Totp TOTPSeed
        {
            get;
            set;
        }

        string TOTPToken
        {
            get;
            set;
        }
    }
}