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
    internal interface ITreeebotEventHandlers
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnUserBanned(object sender, OnUserBannedArgs args);
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnChatCleared(object sender, OnChatClearedArgs args);
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnChannelStateChanged(object sender, OnChannelStateChangedArgs args);
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnGiftedSubscription(object sender, OnGiftedSubscriptionArgs args);
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnReSubscriber(object sender, OnReSubscriberArgs args);
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnCommunitySubscription(object sender, OnCommunitySubscriptionArgs args);
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnNewSubscriber(object sender, OnNewSubscriberArgs args);
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnVIPsReceived(object sender, OnVIPsReceivedArgs args);
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnRaidNotification(object sender, OnRaidNotificationArgs args);
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnBeingHosted(object sender, OnBeingHostedArgs args);
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnConnected(object sender, OnConnectedArgs args);
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnDisconnected(object sender, OnDisconnectedArgs args);
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnMessageReceived(object sender, OnMessageReceivedArgs args);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnPubSubServiceConnected(object sender, EventArgs args);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnPubSubServiceClosed(object sender, EventArgs args);
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnFollow(object sender, OnFollowArgs args);
    }
    internal class TreeebotEventHandlers : ITreeebotEventHandlers
    {
        private readonly ILogger<TreeebotEventHandlers> _logger;
        private readonly ITwitchClient _twitchClient;
        private readonly ITwitchPubSub _twitchPubSub;
        public TreeebotEventHandlers(
            ILogger<TreeebotEventHandlers> logger,
            ITwitchClient twitchChatClient,
            ITwitchPubSub twitchPubSub)
        {
            _logger = logger;
            _twitchClient = twitchChatClient;
            _twitchPubSub = twitchPubSub;
        }

        /// <inheritdoc cref=""/>
        public void OnBan(object sender, OnUserBannedArgs args)
        {
            _logger.LogDebug("Refactor what message to send by resolving messages using the IConfiguration system");
            _twitchClient.SendMessage("itsatreee", $"itsatreeCop itsatreeCop itsatreeCop |BANNED| --->{args.UserBan.Username}<--- |BANNED| FROM WHERE? {args.UserBan.Channel} channel. itsatreeCop itsatreeCop itsatreeCop Suck it!");
        }

        /// <inheritdoc cref="OnUserBanned(object sender, OnUserBannedArgs args)"/>
        public void OnUserBanned(object sender, OnUserBannedArgs args)
        {
            // ban handler
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="OnChatCleared(object sender, OnChatClearedArgs args)"/>
        public void OnChatCleared(object sender, OnChatClearedArgs args)
        {

            throw new NotImplementedException();
        }

        /// <inheritdoc cref="OnChannelStateChanged(object sender, OnChannelStateChangedArgs args)"/>
        public void OnChannelStateChanged(object sender, OnChannelStateChangedArgs args)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="OnGiftedSubscription(object sender, OnGiftedSubscriptionArgs args)"/>
        public void OnGiftedSubscription(object sender, OnGiftedSubscriptionArgs args)
        {
            // Gift and anoymous gift
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="OnReSubscriber(object sender, OnReSubscriberArgs args)"/>
        public void OnReSubscriber(object sender, OnReSubscriberArgs args)
        {
            // re subscribe
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="OnCommunitySubscription(object sender, OnCommunitySubscriptionArgs args)"/>
        public void OnCommunitySubscription(object sender, OnCommunitySubscriptionArgs args)
        {

            throw new NotImplementedException();
        }

        /// <inheritdoc cref="OnNewSubscriber(object sender, OnNewSubscriberArgs args)"/>
        public void OnNewSubscriber(object sender, OnNewSubscriberArgs args)
        {

            throw new NotImplementedException();
        }

        /// <inheritdoc cref="OnVIPsReceived(object sender, OnVIPsReceivedArgs args)"/>
        public void OnVIPsReceived(object sender, OnVIPsReceivedArgs args)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="OnRaidNotification(object sender, OnRaidNotificationArgs args)"/>
        public void OnRaidNotification(object sender, OnRaidNotificationArgs args)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="OnBeingHosted(object sender, OnBeingHostedArgs args)"/>
        public void OnBeingHosted(object sender, OnBeingHostedArgs args)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="OnConnected(object sender, OnConnectedArgs args)"/>
        public void OnConnected(object sender, OnConnectedArgs args)
        {
            _logger.LogInformation("Connected to Twitch Chat, Subscribing to Events...");
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

        /// <inheritdoc cref="OnDisconnected(object sender, OnDisconnectedArgs args)"/>
        public void OnDisconnected(object sender, OnDisconnectedArgs args)
        {
            _logger.LogInformation("Disconnected from Twitch Chat, Unsubscribing from Events...");
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

        /// <inheritdoc cref="OnMessageReceived(object sender, OnMessageReceivedArgs args)"/>
        public void OnMessageReceived(object sender, OnMessageReceivedArgs args)
        {
            // Cheers, onmessage
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="OnPubSubServiceConnected(object, EventArgs)"/>
        public void OnPubSubServiceConnected(object sender, EventArgs args)
        {
            _twitchPubSub.OnFollow += OnFollow;
            _twitchPubSub.SendTopics();
        }

        /// <inheritdoc cref="OnPubSubServiceClosed(object, EventArgs)"/>
        public void OnPubSubServiceClosed(object sender, EventArgs args)
        {
            _twitchPubSub.OnFollow -= OnFollow;
        }

        /// <inheritdoc cref="OnFollow(object sender, OnFollowArgs args)"/>
        public void OnFollow(object sender, OnFollowArgs args)
        {

        }
    }
}
