using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Treeebot.Application.Configuration;
using TwitchLib.Api;
using TwitchLib.Api.Helix;
using TwitchLib.Api.Interfaces;
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
    internal static class TwitchLibServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the required services for interacting with Twitch's Api's
        /// </summary>
        public static IServiceCollection AddTwitchLib(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            AddTwitchAPI(serviceCollection);
            AddTwitchChatClient(serviceCollection);
            AddTwitchPubSub(serviceCollection);
            return serviceCollection;
        }

        /// <summary>
        /// Registers the Twitch V5 and Helix Api client's
        /// </summary>
        private static void AddTwitchAPI(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ITwitchAPI, TwitchAPI>();
        }

        /// <summary>
        /// Registers the Twitch chat client
        /// </summary>
        private static void AddTwitchChatClient(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ITwitchClient, TwitchClient>(services =>
            {
                // Configure the chat client
                var clientOptions = new ClientOptions
                {
                    MessagesAllowedInPeriod = 750,
                    ThrottlingPeriod = TimeSpan.FromSeconds(30)
                };

                // Set up the backing websocket
                var webSocketClient = new WebSocketClient(clientOptions);

                // Create the chat client
                var twitchClientLogger = services.GetService<ILoggerFactory>().CreateLogger<TwitchClient>();
                var twitchClient = new TwitchClient(webSocketClient, ClientProtocol.WebSocket, twitchClientLogger);
                return twitchClient;
            });
        }

        /// <summary>
        /// Registers the Twitch PubSub client
        /// </summary>
        private static void AddTwitchPubSub(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ITwitchPubSub, TwitchPubSub>();
        }
    }
}
