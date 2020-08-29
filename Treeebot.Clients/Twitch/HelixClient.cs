using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Treeebot.Clients.Twitch.HelixModels;
using Treeebot.Clients.Extensions;
using System.Threading.Tasks;
using System.Threading;

namespace Treeebot.Clients.Twitch
{
    public interface IHelixClient
    {
        Task SubscribeToTopic(SubscribeToTopicRequest request, CancellationToken cancellationToken);
    }
    internal class HelixClient : IHelixClient
    {
        private readonly HttpClient _httpClient;
        private readonly HelixConfiguration _helixConfiguration;

        public HelixClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _helixConfiguration = configuration.Get<HelixConfiguration>();
        }

        public async Task SubscribeToTopic(SubscribeToTopicRequest request, CancellationToken cancellationToken)
        {
            using var response = await _httpClient.PostAsync<SubscribeToTopicRequest>("/webhooks/hub", request, cancellationToken);
            throw new NotImplementedException("Response needs to handle failed rrquest");
        }
    }
}
