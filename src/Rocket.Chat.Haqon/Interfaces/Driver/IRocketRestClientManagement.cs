using System.Collections.Generic;
using System.Threading.Tasks;
using Rocket.Chat.Haqon.Models;
using Rocket.Chat.Haqon.Models.RestResults;

namespace Rocket.Chat.Haqon.Interfaces.Driver
{
    public interface IRocketRestClientManagement
    {
        Task LoginRestApi(object loginArgs);

        Task<RestResult> UploadFileToRoomAsync(string roomId, params object[] args);

        /// <summary>
        /// Retrieves the attachments to a temporary folder and returns the paths where they are stored at.
        /// </summary>
        /// <param name="message">Message containing the attachments</param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetAttachments(RocketMessage message);
    }
}
