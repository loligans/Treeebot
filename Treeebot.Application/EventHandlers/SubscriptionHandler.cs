using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;

namespace Treeebot.Application.EventHandlers
{
    public interface ISubscriptionHandler
    {
        void OnGiftedSubscription(object sender, OnGiftedSubscriptionArgs args);
        void OnResubscriber(object sender, OnReSubscriberArgs args);
        void OnCommunitySubscription(object sender, OnCommunitySubscriptionArgs args);
        void OnNewSubscriber(object sender, OnNewSubscriberArgs args);
    }
    internal class SubscriptionHandler : ISubscriptionHandler
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
            throw new NotImplementedException();
        }

        public void OnGiftedSubscription(object sender, OnGiftedSubscriptionArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnNewSubscriber(object sender, OnNewSubscriberArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnResubscriber(object sender, OnReSubscriberArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
