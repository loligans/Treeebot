using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Client;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

namespace Treeebot.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTwitchClient(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var credentials = new ConnectionCredentials("", "");
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };

            var webSocketClient = new WebSocketClient(clientOptions);
            var twitchClient = new TwitchClient(webSocketClient);
            twitchClient.Initialize(credentials, "");
            return serviceCollection;
        }
    }
}
