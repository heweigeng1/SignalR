using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace Tom.WinFrom
{
    public class myHubs:Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }

        public override Task OnConnected()
        {
            new SignalRServer().WriteLogToRtb("客户端连接，连接ID是: " + Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            new SignalRServer().WriteLogToRtb("客户端断开连接，连接ID是: " + Context.ConnectionId);
            return base.OnDisconnected(true);
        }
    }
}
