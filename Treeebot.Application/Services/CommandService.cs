using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Client.Models;

namespace Treeebot.Application.Services
{
    public interface ICommandService
    {
        void ProcessCommand(ChatMessage chatMessage);
    }
    internal class CommandService : ICommandService
    {
        private readonly ILogger<CommandService> _logger;
        public CommandService(ILogger<CommandService> logger)
        {
            _logger = logger;
        }

        public void ProcessCommand(ChatMessage chatMessage)
        {
            _logger.LogDebug("ChatMessage:{0}:{1}", chatMessage.Username, chatMessage.Message);
            throw new NotImplementedException();
        }
    }
}
