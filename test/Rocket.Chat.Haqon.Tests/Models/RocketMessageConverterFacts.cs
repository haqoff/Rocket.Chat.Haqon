using Rocket.Chat.Haqon.Models;

namespace Rocket.Chat.Net.Tests.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using Ploeh.AutoFixture;
    using Xunit;

    public class RocketMessageConverterFacts
    {
        private readonly Fixture AutoFixture = new Fixture();

        [Fact]
        public void Can_write()
        {
            var obj = AutoFixture.Create<RocketMessage>();

            // Act
            var json = JsonConvert.SerializeObject(obj);

            // Assert
        }
    }
}