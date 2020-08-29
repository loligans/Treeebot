using System;
using System.Collections.Generic;
using System.Text;

namespace Treeebot.Clients.Twitch
{
    public class KrakenConfiguration
    {
        public string BaseAddress { get; set; } = "https://api.twitch.tv/kraken";
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
