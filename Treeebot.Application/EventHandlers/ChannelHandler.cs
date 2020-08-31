using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Client.Events;

namespace Treeebot.Application.EventHandlers
{
    public interface IChannelHandler
    {
        void OnChannelStateChanged(object sender, OnChannelStateChangedArgs args);
    }
    internal class ChannelHandler : IChannelHandler
    {
        public void OnChannelStateChanged(object sender, OnChannelStateChangedArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
