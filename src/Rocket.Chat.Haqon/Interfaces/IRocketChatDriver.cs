using System;
using Rocket.Chat.Haqon.Interfaces.Driver;

namespace Rocket.Chat.Haqon.Interfaces
{
    public interface IRocketChatDriver : IDisposable,
                                         IRocketRestClientManagement,
                                         IRocketClientManagement,
                                         IRocketUserManagement,
                                         IRocketMessagingManagement,
                                         IRocketRoomManagement,
                                         IRocketAdministrativeManagement
    {
    }
}