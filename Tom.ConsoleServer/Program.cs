using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tom.ConsoleServer
{
     class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:8180";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
        public class MyHub : Hub
        {
            public void Send(string name, string message)
            {
                Clients.All.addMessage(name, message);
            }
            public override Task OnConnected()
            {
                Console.WriteLine($"{this.Context.ConnectionId}:已经连接!!!");
                return base.OnConnected();
            }
        }
    }
}
