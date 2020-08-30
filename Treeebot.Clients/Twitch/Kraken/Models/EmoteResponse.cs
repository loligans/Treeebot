using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Treeebot.Clients.Twitch.Kraken.Models
{
    internal class EmoteResponse
    {
        [JsonPropertyName("emoticons")]
        public IEnumerable<Emote>? Emoticons { get; set; }
        [JsonPropertyName("emoticon_sets")]
        public IDictionary<string, Emote>? EmoticonSets { get; set; }
    }
}
