﻿using Newtonsoft.Json.Linq;
using Rocket.Chat.Net.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using RestSharp;
using NLog;
using WebSocketSharp;
using RestSharp.Authenticators;
using NLog.LayoutRenderers.Wrappers;
using Rocket.Chat.Net.Models.RestResults;

namespace Rocket.Chat.Net.Driver
{
    public class RestClient : IRestClient
    {
        public RestSharp.RestClient _client;
        private IAuthenticator _authenticator;
        private bool _isLoggedIn;
        ILogger _logger;

        public RestClient(string instanceUrl, ILogger logger)
        {
            _logger = logger;
            _client = new RestSharp.RestClient(instanceUrl + "/api/v1/");
        }

        private bool disposedValue;

        public string Url => throw new NotImplementedException();

        public bool IsDisposed => throw new NotImplementedException();

        public bool IsLoggedIn { get => _isLoggedIn; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method">HTTP method, such as GET, POST, PUT etc.</param>
        /// <param name="path"></param>
        /// <param name="token"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public async Task<JObject> CallAsync(string method, string path, CancellationToken token, params object[] args)
        {
            var request = new RestRequest(path, (Method) Enum.Parse(typeof(Method), method));
            JObject data = JObject.FromObject(args);
            if (data != null)
            {
                request.AddBody(data);
            }
            var response = await _client.ExecuteAsync(request).ConfigureAwait(false);
            return JObject.FromObject(response.Content);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: Verwalteten Zustand (verwaltete Objekte) bereinigen
                    _client.Dispose();
                }

                // TODO: Nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalizer überschreiben
                // TODO: Große Felder auf NULL setzen
                disposedValue = true;
            }
        }

        // // TODO: Finalizer nur überschreiben, wenn "Dispose(bool disposing)" Code für die Freigabe nicht verwalteter Ressourcen enthält
        // ~RestClient()
        // {
        //     // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async Task LoginAsync(object args)
        {
            var response = await CallAsync("POST", "login", CancellationToken.None, args).ConfigureAwait(false);
            var result = response.ToObject<RestResult<RestLoginResult>>();
            if (result.Success)
            {
                string authToken = result.Data.AuthToken;
                string userId = result.Data.UserId;
                _client.Authenticator = new RocketAuthenticator(userId, authToken);
                _isLoggedIn = true;
            } else
            {
                _logger.Error($"Login Error: {result.Error}");
            }
        }
    }

    public class RocketAuthenticator : IAuthenticator
    {
        private string authToken;
        private string userId;

        public RocketAuthenticator(string userId, string authToken) 
        {
            this.authToken = authToken;
            this.userId = userId;
        }

        public ValueTask Authenticate(RestSharp.RestClient client, RestRequest request)
        {
            request.AddHeader("X-Auth-Token", authToken);
            request.AddHeader("X-User-Id", userId);
            return new ValueTask();
        }
    }
}
