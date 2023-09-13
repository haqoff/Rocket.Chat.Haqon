using Rocket.Chat.Haqon.Collections;

namespace Rocket.Chat.Net.Tests.Models.Fixtures
{
    public interface IDummySubscriber
    {
        void React(object sender, StreamCollectionEventArgs streamCollectionEventArgs);
    }
}