namespace Rocket.Chat.Haqon.Models.RestResults
{
    public class RestLoginResult 
    {
        
        public string UserId { get; set; }

        public string AuthToken { get; set; }

        public User Me { get; set; }

    }
}
