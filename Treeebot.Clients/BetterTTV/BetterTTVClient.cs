using System;
using System.Collections.Generic;
using System.Text;

namespace Treeebot.Clients.BetterTTV
{
    public interface IBetterTTVClient
    {
        object GetEmotesByChannel(string channelName);
        object GetGlobalEmotes();
    }
    internal class BetterTTVClient : IBetterTTVClient
    {
        public object GetEmotesByChannel(string channelName)
        {
            throw new NotImplementedException();
        }

        public object GetGlobalEmotes()
        {
            throw new NotImplementedException();
        }
    }
}
