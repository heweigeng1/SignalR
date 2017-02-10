using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Tom.WinFrom.Startup))]
namespace Tom.WinFrom
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
