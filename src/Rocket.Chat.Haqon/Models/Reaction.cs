using System.Collections.Generic;

namespace Rocket.Chat.Haqon.Models
{
    public class Reaction
    {
        public string Name { get; set; }

        public IList<string> Usernames { get; set; }
    }
}