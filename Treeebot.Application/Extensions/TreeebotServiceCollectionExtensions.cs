using Microsoft.Extensions.Configuration;
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
    public static class TreeebotServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the required services and background process for using the Treeebot
        /// </summary>
        public static IServiceCollection AddTreeebot(
            this IServiceCollection serviceCollection, 
            IConfiguration configuration)
        {
            // Register configurations
            serviceCollection.Configure<TwitchWebhooksConfiguration>(configuration.GetSection(nameof(TwitchWebhooksConfiguration)));
            serviceCollection.Configure<TwitchApiConfiguration>(configuration.GetSection(nameof(TwitchApiConfiguration)));
            serviceCollection.Configure<TwitchIrcConfiguration>(configuration.GetSection(nameof(TwitchIrcConfiguration)));
            serviceCollection.Configure<SteamApiConfiguration>(configuration.GetSection(nameof(SteamApiConfiguration)));

            // Register TwitchLib services
            serviceCollection.AddTwitchLib(configuration);

            // Register event handler services
            serviceCollection.AddSingleton<IChannelHandler, ChannelHandler>();
            serviceCollection.AddSingleton<IChatHandler, ChatHandler>();
            serviceCollection.AddSingleton<IStreamHandler, StreamHandler>();
            serviceCollection.AddSingleton<ISubscriptionHandler, SubscriptionHandler>();

            // Register treeebot services
            serviceCollection.AddSingleton<ICommandService, CommandService>();
            serviceCollection.AddSingleton<IEmoteService, EmoteService>();

            // Register the treeebot background process
            serviceCollection.AddHostedService<TreeebotHostedService>();

            return serviceCollection;
        }
    }
}
