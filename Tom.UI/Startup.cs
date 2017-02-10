using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tom.UI.Startup))]
namespace Tom.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           app.MapSignalR();
           ConfigureAuth(app);
        }
    }
}
