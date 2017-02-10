using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tom.WinFrom
{

    public partial class SignalRServer : Form
    {
        public IDisposable SignalR { get; set; }
        public const string ServerUri = "http://localhost:8876"; // SignalR服务地址 
        public SignalRServer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //var url= Dns.GetHostAddresses(Dns.GetHostName()).GetValue(0).ToString();
                SignalR = WebApp.Start(ServerUri);
                rtb.AppendText($"服务器开启:{ServerUri}");
            }
            catch (TargetInvocationException ex)
            {
                SignalR.Dispose();
                rtb.AppendText(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
        public void WriteLogToRtb(string log)
        {
            rtb.AppendText($"{log}/n");
        }
    }
}
