using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Treeebot.Application.Services;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;

namespace Treeebot.Application.EventHandlers
{
    internal interface IChatHandler : IDisposable
    {
        void OnChatCleared(object sender, OnChatClearedArgs args);
        void OnMessageReceived(object sender, OnMessageReceivedArgs args);
        void OnUserBanned(object sender, OnUserBannedArgs args);
        void OnVIPsReceived(object sender, OnVIPsReceivedArgs args);
    }
    internal class ChatHandler : IChatHandler, IDisposable
    {
        private readonly ILogger<ChatHandler> _logger;
        private readonly ITwitchClient _twitchClient;
        private readonly ICommandService _commandService;

        public ChatHandler(ILogger<ChatHandler> logger, ITwitchClient twitchClient, ICommandService commandService)
        {
            _logger = logger;

            _twitchClient = twitchClient;
            _twitchClient.OnChatCleared += OnChatCleared;
            _twitchClient.OnMessageReceived += OnMessageReceived;
            _twitchClient.OnUserBanned += OnUserBanned;
            _twitchClient.OnVIPsReceived += OnVIPsReceived;

            _commandService = commandService;
        }

        public void OnChatCleared(object sender, OnChatClearedArgs args)
        {
            _logger.LogError("{0} not implemented", nameof(OnChatCleared));
        }

        public void OnMessageReceived(object sender, OnMessageReceivedArgs args)
        {
            _logger.LogInformation("{0} not implemented", nameof(OnMessageReceived));
            _commandService.ProcessCommand(args.ChatMessage);
        }

        public void OnUserBanned(object sender, OnUserBannedArgs args)
        {
            _logger.LogError("{0} not implemented", nameof(OnUserBanned));
        }

        public void OnVIPsReceived(object sender, OnVIPsReceivedArgs args)
        {
            _logger.LogError("{0} not implemented", nameof(OnVIPsReceived));
        }

        public void Dispose()
        {
            _twitchClient.OnChatCleared -= OnChatCleared;
            _twitchClient.OnMessageReceived -= OnMessageReceived;
            _twitchClient.OnUserBanned -= OnUserBanned;
            _twitchClient.OnVIPsReceived -= OnVIPsReceived;
        }
    }
}
