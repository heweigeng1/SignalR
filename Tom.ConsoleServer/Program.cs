using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using System;
using System.Threading.Tasks;

namespace Tom.ConsoleServer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string url = "192.168.1.15:8081";
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
                Console.WriteLine($"{name}:{message}");
            }
            public override async Task OnConnected()
            {
                await base.OnConnected();
                Console.WriteLine($"{this.Context.ConnectionId}:已经连接!!!");
                return;
            }
        }
    }
}
