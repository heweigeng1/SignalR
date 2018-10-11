using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;

namespace Tom.WebSocketConsole.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ConnectAsync("ws://localhost:21021/payingcallback");

            Console.ReadKey();
        }
        private static async void ConnectAsync(string BaseUrl)
        {
            ClientWebSocket client = new ClientWebSocket();
            client.Options.AddSubProtocol("protocol1");
            await client.ConnectAsync(new Uri(BaseUrl), CancellationToken.None);
            Console.WriteLine("Connect success");

            await client.SendAsync(new ArraySegment<byte>(AddSeparator(Encoding.UTF8.GetBytes(@"{""protocol"":""json"", ""version"":1}")))
                  , WebSocketMessageType.Text, true, CancellationToken.None);//发送握手包
            Console.WriteLine("Send success");
            var bytes = Encoding.UTF8.GetBytes(@"{
    ""type"": 1,
　　""invocationId"":""123"",
    ""target"": ""log"",
    ""arguments"": [
        ""Test Message""
    ]
    }"")");//发送远程调用 log方法
            await client.SendAsync(new ArraySegment<byte>(AddSeparator(bytes)), WebSocketMessageType.Text, true, CancellationToken.None);
            var buffer = new ArraySegment<byte>(new byte[1024]);
            await client.ReceiveAsync(buffer, CancellationToken.None);
            Console.WriteLine(Encoding.UTF8.GetString(RemoveSeparator(buffer.ToArray())));
            //while (true)
            //{
            //    await client.ReceiveAsync(buffer, CancellationToken.None);
            //    Console.WriteLine(Encoding.UTF8.GetString(RemoveSeparator(buffer.ToArray())));
            //}
        }
        private static byte[] AddSeparator(byte[] data)
        {
            List<byte> t = new List<byte>(data) { 0x1e };//0x1e record separator
            return t.ToArray();
        }
        private static byte[] RemoveSeparator(byte[] data)
        {
            List<byte> t = new List<byte>(data);
            t.Remove(0x1e);
            return t.ToArray();
        }
    }
}
