using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Tom.UI.Hubs
{
    public class perfHub : Hub
    {
        public override Task OnConnected()
        {
            Trace.WriteLine("客户端连接成功");
            return base.OnConnected();
        }
        public void Hello()
        {
            Clients.All.hello();
        }
        public void Send(string name, string msg)
        {
            Clients.All.sendMessage(name,msg);
        }
    }
}