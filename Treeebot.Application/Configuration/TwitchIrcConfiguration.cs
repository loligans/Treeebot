using System;
using System.Collections.Generic;
using System.Text;

namespace Treeebot.Application.Configuration
{
    public class TwitchIrcConfiguration
    {
        public string? UserId { get; set; }
        public string? UserOAuthPassword { get; set; }
        public IEnumerable<string?>? Channels { get; set; }
    }
}
