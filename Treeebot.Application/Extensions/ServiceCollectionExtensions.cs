﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Treeebot.Application.Configuration;
using Treeebot.Application.EventHandlers;
using Treeebot.Application.Services;
using TwitchLib.Api;
using TwitchLib.Api.Interfaces;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Interfaces;
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
            // Resolve configuration
            serviceCollection.Configure<TwitchWebhooksConfiguration>(configuration.GetSection(nameof(TwitchWebhooksConfiguration)));
            serviceCollection.Configure<TwitchApiConfiguration>(configuration.GetSection(nameof(TwitchApiConfiguration)));
            serviceCollection.Configure<SteamApiConfiguration>(configuration.GetSection(nameof(SteamApiConfiguration)));

            // Set up Twitch services
            AddTwitchAPI(serviceCollection);
            AddTwitchChatClient(serviceCollection);
            AddTwitchPubSub(serviceCollection);

            // Register event handlers
            serviceCollection.AddSingleton<IChannelHandler, ChannelHandler>();
            serviceCollection.AddSingleton<IChatHandler, ChatHandler>();
            serviceCollection.AddSingleton<IStreamHandler, StreamHandler>();
            serviceCollection.AddSingleton<ISubscriptionHandler, SubscriptionHandler>();

            // Register services
            serviceCollection.AddSingleton<ICommandService, CommandService>();
            serviceCollection.AddSingleton<IEmoteService, EmoteService>();

            return serviceCollection;
        }

        /// <summary>
        /// Registers the Twitch Api into the DI container
        /// </summary>
        private static void AddTwitchAPI(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ITwitchAPI, TwitchAPI>();
        }

        /// <summary>
        /// Registers the Twitch chat client into the DI container
        /// </summary>
        private static void AddTwitchChatClient(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ConnectionCredentials>();
            serviceCollection.AddSingleton<IClientOptions, ClientOptions>();
            serviceCollection.AddSingleton<IClient, WebSocketClient>();
            serviceCollection.AddSingleton<ITwitchClient, TwitchClient>();
            serviceCollection.AddSingleton<ITwitchClient, TwitchClient>(services =>
            {
                var twitchConfig = services.GetService<IOptions<TwitchApiConfiguration>>();
                var credentials = new ConnectionCredentials(twitchConfig.Value.ClientId, twitchConfig.Value.ClientSecret);
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

                twitchClient.Initialize(credentials, "itsatreee");
                return twitchClient;
            });
        }

        /// <summary>
        /// Registers the Twitch PubSub client into the DI container
        /// </summary>
        private static void AddTwitchPubSub(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ITwitchPubSub, TwitchPubSub>(services =>
            {
                var factory = services.GetService<ILoggerFactory>();
                var logger = factory.CreateLogger<TwitchPubSub>();
                var client = new TwitchPubSub(logger);
                return client;
            });
        }
    }
}
