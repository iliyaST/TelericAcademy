using Owin;
using Microsoft.Owin;
using Ninject;
using BirthdaySite.App_Start.Helpers;
using Microsoft.AspNet.SignalR;
using MVCTemplate.Services.Data;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRChat.Hubs;
using Microsoft.AspNet.SignalR.Infrastructure;

[assembly: OwinStartupAttribute(typeof(BirthdaySite.Startup))]
namespace BirthdaySite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var kernel = new StandardKernel();
            var resolver = new NinjectSignalRDependencyResolver(kernel);
            var config = new HubConfiguration();

            kernel.Bind<IGroupService>()
           .To<GroupService>()
           .InSingletonScope();

            kernel.Bind(typeof(IHubConnectionContext<dynamic>)).ToMethod(context =>
                    resolver.Resolve<IConnectionManager>().GetHubContext<Chat>().Clients
                     ).WhenInjectedInto<IGroupService>();

            config.Resolver = resolver;

            this.ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
