using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TwitchLib.Client.Interfaces;
using TwitchLib.PubSub.Events;
using TwitchLib.PubSub.Interfaces;
using TwitchLib.Client.Events;

namespace Treeebot.Application
{
    public interface ITreeebotEventHandlers : IDisposable
    {
        void OnUserBanned(object sender, OnUserBannedArgs args);
        void OnChatCleared(object sender, OnChatClearedArgs args);
        void OnChannelStateChanged(object sender, OnChannelStateChangedArgs args);
        void OnGiftedSubscription(object sender, OnGiftedSubscriptionArgs args);
        void OnReSubscriber(object sender, OnReSubscriberArgs args);
        void OnCommunitySubscription(object sender, OnCommunitySubscriptionArgs args);
        void OnNewSubscriber(object sender, OnNewSubscriberArgs args);
        void OnVIPsReceived(object sender, OnVIPsReceivedArgs args);
        void OnRaidNotification(object sender, OnRaidNotificationArgs args);
        void OnBeingHosted(object sender, OnBeingHostedArgs args);
        void OnConnected(object sender, OnConnectedArgs args);
        void OnMessageReceived(object sender, OnMessageReceivedArgs args);
    }
    internal class TreeebotEventHandlers : ITreeebotEventHandlers, IDisposable
    {
        private readonly ILogger<TreeebotEventHandlers> _logger;
        private readonly ITwitchClient _twitchClient;
        public TreeebotEventHandlers(
            ILogger<TreeebotEventHandlers> logger,
            ITwitchClient twitchChatClient)
        {
            _logger = logger;
            _twitchClient = twitchChatClient;

            _twitchClient.OnUserBanned += OnUserBanned;
            _twitchClient.OnChatCleared += OnChatCleared;
            _twitchClient.OnChannelStateChanged += OnChannelStateChanged;
            _twitchClient.OnGiftedSubscription += OnGiftedSubscription;
            _twitchClient.OnReSubscriber += OnReSubscriber;
            _twitchClient.OnCommunitySubscription += OnCommunitySubscription;
            _twitchClient.OnNewSubscriber += OnNewSubscriber;
            _twitchClient.OnVIPsReceived += OnVIPsReceived;
            _twitchClient.OnRaidNotification += OnRaidNotification;
            _twitchClient.OnBeingHosted += OnBeingHosted;
            _twitchClient.OnConnected += OnConnected;
            _twitchClient.OnMessageReceived += OnMessageReceived;
        }

        public void OnBan(object sender, OnUserBannedArgs args)
        {
            _logger.LogDebug("Refactor what message to send by resolving messages using the IConfiguration system");
            _twitchClient.SendMessage("itsatreee", $"itsatreeCop itsatreeCop itsatreeCop |BANNED| --->{args.UserBan.Username}<--- |BANNED| FROM WHERE? {args.UserBan.Channel} channel. itsatreeCop itsatreeCop itsatreeCop Suck it!");
        }

        public void OnUserBanned(object sender, OnUserBannedArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnChatCleared(object sender, OnChatClearedArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnChannelStateChanged(object sender, OnChannelStateChangedArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnGiftedSubscription(object sender, OnGiftedSubscriptionArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnReSubscriber(object sender, OnReSubscriberArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnCommunitySubscription(object sender, OnCommunitySubscriptionArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnNewSubscriber(object sender, OnNewSubscriberArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnVIPsReceived(object sender, OnVIPsReceivedArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnRaidNotification(object sender, OnRaidNotificationArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnBeingHosted(object sender, OnBeingHostedArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnConnected(object sender, OnConnectedArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnMessageReceived(object sender, OnMessageReceivedArgs args)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _twitchClient.OnUserBanned -= OnUserBanned;
            _twitchClient.OnChatCleared -= OnChatCleared;
            _twitchClient.OnChannelStateChanged -= OnChannelStateChanged;
            _twitchClient.OnGiftedSubscription -= OnGiftedSubscription;
            _twitchClient.OnReSubscriber -= OnReSubscriber;
            _twitchClient.OnCommunitySubscription -= OnCommunitySubscription;
            _twitchClient.OnNewSubscriber -= OnNewSubscriber;
            _twitchClient.OnVIPsReceived -= OnVIPsReceived;
            _twitchClient.OnRaidNotification -= OnRaidNotification;
            _twitchClient.OnBeingHosted -= OnBeingHosted;
            _twitchClient.OnConnected -= OnConnected;
            _twitchClient.OnMessageReceived -= OnMessageReceived;
        }
    }
}
