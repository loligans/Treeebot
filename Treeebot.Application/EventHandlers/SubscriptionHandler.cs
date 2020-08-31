using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;

namespace Treeebot.Application.EventHandlers
{
    internal interface ISubscriptionHandler : IDisposable
    {
        void OnGiftedSubscription(object sender, OnGiftedSubscriptionArgs args);
        void OnResubscriber(object sender, OnReSubscriberArgs args);
        void OnCommunitySubscription(object sender, OnCommunitySubscriptionArgs args);
        void OnNewSubscriber(object sender, OnNewSubscriberArgs args);
    }
    internal class SubscriptionHandler : ISubscriptionHandler, IDisposable
    {
        private readonly ILogger<SubscriptionHandler> _logger;
        private readonly ITwitchClient _twitchClient;
        public SubscriptionHandler(ILogger<SubscriptionHandler> logger, ITwitchClient twitchClient)
        {
            _logger = logger;

            _twitchClient = twitchClient;
            _twitchClient.OnCommunitySubscription += OnCommunitySubscription;
            _twitchClient.OnGiftedSubscription += OnGiftedSubscription;
            _twitchClient.OnCommunitySubscription += OnCommunitySubscription;
            _twitchClient.OnNewSubscriber += OnNewSubscriber;
        }

        public void OnCommunitySubscription(object sender, OnCommunitySubscriptionArgs args)
        {
            _logger.LogError("{0} not implemented", nameof(OnCommunitySubscription));
        }

        public void OnGiftedSubscription(object sender, OnGiftedSubscriptionArgs args)
        {
            _logger.LogError("{0} not implemented", nameof(OnGiftedSubscription));
        }

        public void OnNewSubscriber(object sender, OnNewSubscriberArgs args)
        {
            _logger.LogError("{0} not implemented", nameof(OnNewSubscriber));
        }

        public void OnResubscriber(object sender, OnReSubscriberArgs args)
        {
            _logger.LogError("{0} not implemented", nameof(OnResubscriber));
        }

        public void Dispose()
        {
            _twitchClient.OnCommunitySubscription -= OnCommunitySubscription;
            _twitchClient.OnGiftedSubscription -= OnGiftedSubscription;
            _twitchClient.OnCommunitySubscription -= OnCommunitySubscription;
            _twitchClient.OnNewSubscriber -= OnNewSubscriber;
        }
    }
}
