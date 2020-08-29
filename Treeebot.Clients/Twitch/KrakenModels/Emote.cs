using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Treeebot.Clients.Twitch.KrakenModels
{
    public class Emote
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("emoticon_set")]
        public int? EmoteSet { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
