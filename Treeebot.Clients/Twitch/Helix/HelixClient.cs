using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Treeebot.Clients.Twitch.Helix.Models;
using Treeebot.Extensions;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace Treeebot.Clients.Twitch.Helix
{
    public interface IHelixClient
    {
        /// <summary>
        /// Subscribe to or unsubscribe from events for a specified topic.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="bool"/> indicating if the request completed successfully.</returns>
        Task<bool> SubscribeToTopic(SubscribeToTopicRequest request, CancellationToken cancellationToken);
    }
    internal class HelixClient : IHelixClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HelixClient> _logger;

        public HelixClient(HttpClient httpClient, ILogger<HelixClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<bool> SubscribeToTopic(SubscribeToTopicRequest request, CancellationToken cancellationToken)
        {
            using var response = await _httpClient.PostAsync<SubscribeToTopicRequest>("/webhooks/hub", request, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("Failed to subscribe to Topic: {0}", request.Topic);
                return false;
            }
            return true;
        }
    }
}
