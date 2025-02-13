﻿using Rocket.Chat.Haqon.Driver;
using Rocket.Chat.Haqon.Interfaces;

namespace Rocket.Chat.Net.Tests.Driver
{
    using System;
    using System.Threading;

    using FluentAssertions;

    using Newtonsoft.Json;
    using NLog;
    using NSubstitute;

    using Ploeh.AutoFixture;
    using WebSocket4Net;
    using Xunit;

    public class DdpFacts : IDisposable
    {
        private static readonly Fixture AutoFixture = new Fixture();

        private readonly ILogger _helper;
        private readonly IWebSocketWrapper _socket; 

        private CancellationToken TimeoutToken => CreateTimeoutToken();

        public DdpFacts()
        {
            _helper = NLog.LogManager.GetCurrentClassLogger();
            // new WebSocket();
            _socket = Substitute.For<IWebSocketWrapper>();
        }

        [Fact]
        public void Connecting_should_set_session()
        {
            var client = new DdpClient(_socket, _helper);

            var sessionId = AutoFixture.Create<string>();
            var message = new
            {
                session = sessionId,
                msg = "connected"
            };
            var jsonMessage = new MessageReceivedEventArgs(JsonConvert.SerializeObject(message));

            // Act
            _socket.MessageReceived += Raise.Event<EventHandler<MessageReceivedEventArgs>>(new object(), jsonMessage);

            // Assert
            client.SessionId.Should().Be(sessionId);
        }

        [Fact]
        public void Can_unsubscribe()
        {
            var client = new DdpClient(_socket, _helper);

            var subId = AutoFixture.Create<string>();
            var message = new
            {
                id = subId,
                msg = "nosub"
            };
            var jsonMessage = new MessageReceivedEventArgs(JsonConvert.SerializeObject(message));

            // Act
            var task = client.UnsubscribeAsync(subId, TimeoutToken);
            _socket.MessageReceived += Raise.Event<EventHandler<MessageReceivedEventArgs>>(new object(), jsonMessage);

            Action action = async () => await task;

            // Assert
            action.ShouldNotThrow<OperationCanceledException>();
        }

        [Fact]
        public void Can_reconnect()
        {
            var reconnected = false;
            var client = new DdpClient(_socket, _helper);
            client.DdpReconnect += () => reconnected = true;

            var firstMessage = new MessageReceivedEventArgs(JsonConvert.SerializeObject(new
            {
                session = AutoFixture.Create<string>(),
                msg = "connected"
            }));

            var secondMessage = new MessageReceivedEventArgs(JsonConvert.SerializeObject(new
            {
                session = AutoFixture.Create<string>(),
                msg = "connected"
            }));

            // Act
            _socket.MessageReceived += Raise.Event<EventHandler<MessageReceivedEventArgs>>(new object(), firstMessage);
            _socket.Closed += Raise.Event<EventHandler>();
            _socket.MessageReceived += Raise.Event<EventHandler<MessageReceivedEventArgs>>(new object(), secondMessage);

            // Assert
            _socket.Received().Open();
            reconnected.Should().BeTrue();
        }

        [Fact]
        public void On_error_log()
        {
            var logger = Substitute.For<ILogger>();
            // ReSharper disable once UnusedVariable
            var client = new DdpClient(_socket, logger);

            var message = AutoFixture.Create<string>();
            var exception = new Exception(message);

            // Act
            _socket.Error += Raise.Event<EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>>(new object(), new SuperSocket.ClientEngine.ErrorEventArgs(exception));

            // Assert
            logger.Received().Info($"ERROR: {message}");
        }

        private CancellationToken CreateTimeoutToken()
        {
            const int timeoutSeconds = 30;
            var source = new CancellationTokenSource();
            source.CancelAfter(TimeSpan.FromSeconds(timeoutSeconds));

            return source.Token;
        }

        public void Dispose()
        {
            
        }
    }
}