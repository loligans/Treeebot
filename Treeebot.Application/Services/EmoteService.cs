using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Treeebot.Application.Services
{
    /// <summary>
    /// Service for managing and consuming emoticons
    /// </summary>
    public interface IEmoteService
    {

    }
    /// <inheritdoc cref="IEmoteService"/>
    internal class EmoteService : IEmoteService
    {
        private readonly ILogger<EmoteService> _logger;
        public EmoteService(ILogger<EmoteService> logger)
        {
            _logger = logger;
        }
    }
}
