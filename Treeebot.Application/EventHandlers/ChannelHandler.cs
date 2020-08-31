using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;

namespace Treeebot.Application.EventHandlers
{
    internal interface IChannelHandler : IDisposable
    {
        void OnChannelStateChanged(object sender, OnChannelStateChangedArgs args);
    }
    internal class ChannelHandler : IChannelHandler, IDisposable
    {
        private readonly ILogger<ChannelHandler> _logger;
        private readonly ITwitchClient _twitchClient;
        public ChannelHandler(ILogger<ChannelHandler> logger, ITwitchClient twitchClient)
        {
            _logger = logger;

            _twitchClient = twitchClient;
            _twitchClient.OnChannelStateChanged += OnChannelStateChanged;
        }

        public void OnChannelStateChanged(object sender, OnChannelStateChangedArgs args)
        {
            _logger.LogError("{0} not implemented", nameof(OnChannelStateChanged));
        }

        public void Dispose()
        {
            _twitchClient.OnChannelStateChanged -= OnChannelStateChanged;
        }
    }
}
