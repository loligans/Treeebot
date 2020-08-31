using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;
using TwitchLib.PubSub.Events;
using TwitchLib.PubSub.Interfaces;

namespace Treeebot.Application.EventHandlers
{
    internal interface IStreamHandler
    {
        void OnBeingHosted(object sender, OnBeingHostedArgs args);
        void OnRaidNotification(object sender, OnRaidNotificationArgs args);
        void OnFollow(object sender, OnFollowArgs args);
    }
    internal class StreamHandler : IStreamHandler
    {
        private readonly ILogger<StreamHandler> _logger;
        private readonly ITwitchClient _twitchClient;
        private readonly ITwitchPubSub _twitchPubSub;
        public StreamHandler(ILogger<StreamHandler> logger, ITwitchClient twitchClient, ITwitchPubSub twitchPubSub)
        {
            _logger = logger;

            _twitchClient = twitchClient;
            _twitchClient.OnRaidNotification += OnRaidNotification;
            _twitchClient.OnBeingHosted += OnBeingHosted;

            _twitchPubSub = twitchPubSub;
            _twitchPubSub.OnFollow += OnFollow;
        }
        public void OnBeingHosted(object sender, OnBeingHostedArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnFollow(object sender, OnFollowArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnRaidNotification(object sender, OnRaidNotificationArgs args)
        {
            
            throw new NotImplementedException();
        }
    }
}
