![Rocket.Chat.Net](/docs/images/icon.png)

# Rocket.Chat.Net

|                     | Pre-release                                 | Stable Release |
| ------------------- | ------------------------------------------- | ---            |
| Rocket.Chat.Net     | [![NuGet][Base-Nuget-Pre-Img]][Base-Nuget-Link] | [![NuGet][Base-Nuget-Img]][Base-Nuget-Link] |
| Rocket.Chat.Net.Bot | [![NuGet][Bot-Nuget-Pre-Img]][Bot-Nuget-Link]   | [![NuGet][Bot-Nuget-Img]][Bot-Nuget-Link] |

[Base-Nuget-Pre-Img]: https://img.shields.io/nuget/vpre/Rocket.Chat.Net.svg?style=flat-square&maxAge=3600
[Bot-Nuget-Pre-Img]: https://img.shields.io/nuget/vpre/Rocket.Chat.Net.Bot.svg?style=flat-square&maxAge=3600
[Base-Nuget-Img]: https://img.shields.io/nuget/v/Rocket.Chat.Net.svg?style=flat-square&maxAge=3600
[Bot-Nuget-Img]: https://img.shields.io/nuget/v/Rocket.Chat.Net.Bot.svg?style=flat-square&maxAge=3600

[Base-Nuget-Link]: https://www.nuget.org/packages/Rocket.Chat.Net/
[Bot-Nuget-Link]: https://www.nuget.org/packages/Rocket.Chat.Net.Bot/

[![Build status](https://img.shields.io/appveyor/ci/Silvenga/rocket-chat-net.svg?style=flat-square&maxAge=300&label=appveyor)](https://ci.appveyor.com/project/Silvenga/rocket-chat-net) 
[![Build status](https://img.shields.io/travis/Silvenga/Rocket.Chat.Net.svg?style=flat-square&maxAge=300&label=travis)](https://travis-ci.org/Silvenga/Rocket.Chat.Net) 
[![Coverage Status](https://img.shields.io/coveralls/Silvenga/Rocket.Chat.Net.svg?style=flat-square&maxAge=300)](https://coveralls.io/github/Silvenga/Rocket.Chat.Net?branch=master)
[![License](https://img.shields.io/github/license/Silvenga/Rocket.Chat.Net.svg?style=flat-square&maxAge=604800)](https://github.com/Silvenga/Rocket.Chat.Net/blob/master/LICENSE)
![Rocket.Chat Compatibility](https://img.shields.io/badge/Rocket.Chat%20Compatibility-0.35.0-red.svg?maxAge=3600&style=flat-square)

A Rocket.Chat real-time, managed, .Net driver, and bot. 

> Not compatible with 0.36.0, 0.37.0, 0.37.1, see https://github.com/Silvenga/Rocket.Chat.Net/issues/2
>  Waiting for things to settle down. 

## Driver Usage

```csharp
const string username = "m@silvenga.com";
const string password = "silverlight";
const string rocketServerUrl = "demo.rocket.chat:3000";
const bool useSsl = false;

ILoginOption loginOption = new LdapLoginOption
{
    Username = username,
    Password = password
};

IRocketChatDriver driver = new RocketChatDriver(rocketServerUrl, useSsl);

await driver.ConnectAsync(); // Connect to server
await driver.LoginAsync(loginOption); // Login via LDAP
await driver.SubscribeToRoomAsync(); // Listen on all rooms

driver.MessageReceived += Console.WriteLine;

var generalRoomIdResult = await driver.GetRoomIdAsync("general");
if (generalRoomIdResult.HasError)
{
    throw new Exception("Could not find room by name.");
}

var generalRoomId = generalRoomIdResult.Result;
await driver.SendMessageAsync("message", generalRoomId);
```

## Building/Testing

[docs/environment.md](docs/environment.md)

## Version compatibility changelogs

[version-compatibility.md](docs/version-compatibility.md)

## Feature Support/TODO

[docs/todo.md](docs/todo.md)