using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;
using TwitchLib.PubSub;
using TwitchLib.PubSub.Interfaces;

namespace Treeebot.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTreeebot(
            this IServiceCollection serviceCollection, 
            IConfiguration configuration)
        {
            serviceCollection.AddSingleton<ITreeebotEventHandlers, TreeebotEventHandlers>();

            serviceCollection.AddSingleton<ITwitchClient, TwitchClient>(services =>
            {
                var credentials = new ConnectionCredentials("", "");
                var clientOptions = new ClientOptions
                {
                    MessagesAllowedInPeriod = 750,
                    ThrottlingPeriod = TimeSpan.FromSeconds(30)
                };

                // Set up the backing websocket client
                var webSocketClient = new WebSocketClient(clientOptions);

                // Set up the Twitch chat client
                var factory = services.GetService<ILoggerFactory>();
                var logger = factory.CreateLogger<TwitchClient>();
                var twitchClient = new TwitchClient(
                    webSocketClient, 
                    ClientProtocol.WebSocket, 
                    logger);

                twitchClient.Initialize(credentials, "");
                return twitchClient;
            });

            serviceCollection.AddSingleton<ITwitchPubSub, TwitchPubSub>(services =>
            {
                var factory = services.GetService<ILoggerFactory>();
                var logger = factory.CreateLogger<TwitchPubSub>();
                var client = new TwitchPubSub(logger);
                
                client.OnFollow += null;
                
                return client;
            });

            var client = serviceCollection.BuildServiceProvider().GetService<ITreeebotEventHandlers>();
            

            // twitchClient.OnMessageReceived
            // twitchClient.OnConnected
            // twitchClient.Connect()

            return serviceCollection;
        }
    }
}
