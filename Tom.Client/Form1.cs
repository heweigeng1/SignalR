using Microsoft.AspNet.SignalR.Client;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace Tom.Client
{
    public partial class Form1 : Form
    {
        public IHubProxy HubProxy { get; set; }

        private const string ServerUri = "http://localhost:21021/payingcallback";
        public HubConnection Connection { get; set; }
        public string user { get; set; } = Guid.NewGuid().ToString();
        public Form1()
        {
            InitializeComponent();
            ConnectAsync();
            setLogToRtb(user);
        }
        private async void ConnectAsync()
        {
            Connection = new HubConnection("http://localhost:21021/payingcallback", useDefaultUrl: false);
            // 创建一个集线器代理对象
            HubProxy = Connection.CreateHubProxy("PayingCallBackHub");

            //供服务器调用
            HubProxy.On<string, string>("addMessage", (name, message) => RTB_MSG.Invoke(new Action(() => setLogToRtb($"{name}: {message}")))
                );
            //开启连接
            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException ex)
            {
                setLogToRtb($"请检查服务是否开启：{ServerUri }!!");
                Console.WriteLine($"error:{ex.Message}");
                // 连接失败
                return;
            }
            setLogToRtb("连接成功!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 通过代理来调用服务端的Send方法
            // 服务端Send方法再调用客户端的AddMessage方法将消息输出到消息框中
            HubProxy.Invoke("Send", user, msg.Text.Trim());
            msg.Text = "";
        }
        public void setLogToRtb(string msg)
        {
            this.RTB_MSG.AppendText($"{msg}\n");
        }
    }
}
