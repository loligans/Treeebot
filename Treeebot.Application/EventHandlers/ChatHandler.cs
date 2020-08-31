using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Treeebot.Application.Services;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;

namespace Treeebot.Application.EventHandlers
{
    public interface IChatHandler
    {
        void OnChatCleared(object sender, OnChatClearedArgs args);
        void OnMessageReceived(object sender, OnMessageReceivedArgs args);
        void OnUserBanned(object sender, OnUserBannedArgs args);
        void OnVIPsReceived(object sender, OnVIPsReceivedArgs args);
    }
    internal class ChatHandler : IChatHandler
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
            throw new NotImplementedException();
        }

        public void OnMessageReceived(object sender, OnMessageReceivedArgs args)
        {
            _commandService.ProcessCommand(args.ChatMessage);
        }

        public void OnUserBanned(object sender, OnUserBannedArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnVIPsReceived(object sender, OnVIPsReceivedArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
