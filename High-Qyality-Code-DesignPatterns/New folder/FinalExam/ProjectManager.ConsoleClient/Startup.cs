using Ninject;
using ProjectManager.Configs;
using ProjectManager.Framework.Core.Common.Contracts;

namespace ProjectManager.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            //var configProvider = new ConfigurationProvider();

            // This is an example of how to create the caching service. Think about how and where to use it in the project.
            //var cacheService = new CachingService(configProvider.CacheDurationInSeconds);

            IKernel kernel = new StandardKernel(new NinjectManagerModule());

            IEngine engine = kernel.Get<IEngine>();

            engine.Start();
        }
    }
}
