using System;
using System.Collections.Generic;
using System.Text;

namespace Treeebot.Application.Configuration
{
    public class TwitchWebhooksConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        public Uri? UserFollowsCallback { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Uri? StreamChangedCallback { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Uri? UserChangedCallback { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Uri? ExtensionTransactionCreatedCallback { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Uri? ModeratorChangeEventsCallback { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Uri? ChannelBanChangeEventsCallback { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Uri? SubscriptionEventsCallback { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Uri? HypeTrainEventCallback { get; set; }
    }
}
