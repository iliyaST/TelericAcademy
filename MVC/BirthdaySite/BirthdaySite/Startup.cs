using Owin;
using Microsoft.Owin;
using Ninject;
using BirthdaySite.App_Start.Helpers;
using Microsoft.AspNet.SignalR;
using MVCTemplate.Services.Data;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRChat.Hubs;
using Microsoft.AspNet.SignalR.Infrastructure;
using MVCTemplate.Data.Common;

[assembly: OwinStartupAttribute(typeof(BirthdaySite.Startup))]
namespace BirthdaySite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
