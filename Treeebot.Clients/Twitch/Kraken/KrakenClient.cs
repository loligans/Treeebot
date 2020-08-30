using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Linq;
using Treeebot.Clients.Twitch.Kraken.Models;
using Treeebot.Extensions;
using System.Threading;
using System.Threading.Tasks;

namespace Treeebot.Clients.Twitch.Kraken
{
    /// <summary>
    /// A Twitch v5 Api client implementation
    /// </summary>
    public interface IKrakenClient
    {
        /// <summary>
        /// Gets all chat emoticons (not including their images) in one or more specified sets.
        /// </summary>
        /// <param name="emoteSets">Specifies the set(s) of emoticons to retrieve. If no set is specified, all chat emoticons are returned.</param>
        Task<IEnumerable<Emote>> GetChatEmotesBySet(int[]? emoteSets, CancellationToken cancellationToken);
        /// <summary>
        /// Gets a list of the emojis and emoticons that the specified user can use in chat. These are both the globally available ones and the channel-specific ones (which can be accessed by any user subscribed to the channel).
        /// </summary>
        /// <param name="userId">The id of the user who's emotes to grab.</param>
        Task<IEnumerable<Emote>> GetUserEmotes(int userId, CancellationToken cancellationToken);
    }
    /// <inheritdoc cref="IKrakenClient"/>
    internal class KrakenClient : IKrakenClient
    {
        private readonly HttpClient _httpClient;
        private readonly KrakenConfiguration _krakenConfiguration;
        public KrakenClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _krakenConfiguration = configuration.Get<KrakenConfiguration>();
        }

        /// <inheritdoc cref="IKrakenClient.GetChatEmotesBySet(string)"/>
        public async Task<IEnumerable<Emote>> GetChatEmotesBySet(int[]? emoteSets, CancellationToken cancellationToken)
        {
            var queryString = emoteSets is null ? "" : $"?emotesets={string.Join(",", emoteSets)}";
            var emoteBySetResponse = await _httpClient
                .GetAsync<EmoteResponse>(
                    $"/chat/emoticon_images{queryString}", 
                    cancellationToken);

            return ParseEmoteResponse(emoteBySetResponse);
        }

        /// <inheritdoc cref="IKrakenClient.GetUserEmotes(string, CancellationToken)"/>
        public async Task<IEnumerable<Emote>> GetUserEmotes(int userId, CancellationToken cancellationToken)
        {
            var userEmotesResponse = await _httpClient
                .GetAsync<EmoteResponse>(
                    $"/users/{userId}/emotes",
                    cancellationToken);

            return ParseEmoteResponse(userEmotesResponse);
        }

        private IEnumerable<Emote> ParseEmoteResponse(EmoteResponse? response)
        {
            // Parse selected emoticon sets
            if (response?.EmoticonSets != null)
            {
                IEnumerable<Emote> emoticons = response.EmoticonSets.Select(emote =>
                {
                    var success = int.TryParse(emote.Key, out var result);
                    emote.Value.EmoteSet = result;
                    return emote.Value;
                });

                return emoticons;
            }

            // Parse all emoticons
            else if (response?.Emoticons != null)
            {
                return response.Emoticons;
            }

            // No emoticons returned
            return Array.Empty<Emote>();
        } 
    }
}
