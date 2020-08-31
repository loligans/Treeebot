using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Client.Models;

namespace Treeebot.Application.Services
{
    /// <summary>
    /// Service for executing chat commands
    /// </summary>
    public interface ICommandService
    {
        void ProcessCommand(ChatMessage chatMessage);
    }

    /// <inheritdoc cref="ICommandService"/>
    internal class CommandService : ICommandService
    {
        private readonly ILogger<CommandService> _logger;
        public CommandService(ILogger<CommandService> logger)
        {
            _logger = logger;
        }

        public void ProcessCommand(ChatMessage chatMessage)
        {
            _logger.LogError("{0} not implemented", nameof(ProcessCommand));
        }
    }
}
