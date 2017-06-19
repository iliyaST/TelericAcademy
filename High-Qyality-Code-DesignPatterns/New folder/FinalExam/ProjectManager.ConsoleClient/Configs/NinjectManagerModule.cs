using Ninject.Modules;
using Ninject.Extensions.Conventions;
using System.IO;
using System.Reflection;
using ProjectManager.Framework.Core;
using ProjectManager.ConsoleClient.Configs;
using ProjectManager.Framework.Core.Common.Providers;
using ProjectManager.Framework.Core.Common.Contracts;
using Ninject;
using ProjectManager.Framework.Core.Commands.Creational;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Listing;
using Ninject.Extensions.Interception.Infrastructure.Language;
using ProjectManager.ConsoleClient.Interceptors;
using ProjectManager.Framework.Core.Commands.Decorators;
using ProjectManager.Framework.Services;

namespace ProjectManager.Configs
{
    public class NinjectManagerModule : NinjectModule
    {
        private const string CreateProject = "createproject";
        private const string CreateUser = "createuser";
        private const string CreateTask = "createtask";

        private const string ListProjects = "listprojects";
        private const string ListProjectDetails = "listprojectdetails";

        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .Where(type => type != typeof(Engine) && type != typeof(CachingService))
                .BindDefaultInterface()
                .Configure(binding => binding.InSingletonScope());
            });

            Bind<IEngine>().To<Engine>().InSingletonScope();
            Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            var processor = Bind<IProcessor>().To<CommandProcessor>().InSingletonScope();

            Bind<ICommand>().To<CreateProjectCommand>().InSingletonScope().Named(CreateProject.ToLower());
            Bind<ICommand>().To<CreateUserCommand>().InSingletonScope().Named(CreateUser.ToLower());
            Bind<ICommand>().To<CreateTaskCommand>().InSingletonScope().Named(CreateTask.ToLower());            
            Bind<ICommand>().To<ListProjectDetailsCommand>().InSingletonScope().Named(ListProjectDetails.ToLower());

            Bind<ICommand>()
                .To<CacheableCommand>().InSingletonScope()
                .Named(ListProjects.ToLower());

            Bind<ICommand>().ToMethod(context =>
            {
                return this.Kernel.Get<ListProjectsCommand>();
            }).WhenInjectedInto<CacheableCommand>().InSingletonScope();

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            
            Bind<ICachingService>().To<CachingService>().InSingletonScope().WithConstructorArgument(configurationProvider.CacheDurationInSeconds);
            Bind<ILogger>().To<FileLogger>().InSingletonScope().WithConstructorArgument(configurationProvider.LogFilePath);

            processor.Intercept().With<WriteInterceptor>();
            processor.Intercept().With<LogErrorInterceptor>();
        }
    }
}
