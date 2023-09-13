using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Rocket.Chat.Haqon.Models.RestResults;

namespace Rocket.Chat.Haqon.Interfaces
{
    public interface IRestClient : IDisposable 
    {
        string Url { get; }
        bool IsDisposed { get; }
        Task<JObject> CallAsync(RestSharp.Method method, string path, CancellationToken token, params object[] args);

        Task<string> DownloadAsync(string path, CancellationToken token);

        Task<JObject> UploadAsync(RestSharp.Method method, string path, CancellationToken token, params object[] args);
        Task<RestResult> LoginAsync(object args);

    }
}
