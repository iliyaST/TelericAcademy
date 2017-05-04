using ProjectManager.Commands;
using ProjectManager.Common;
using Pesho.Core.Providers;
using ProjectManager.Data;
using ProjectManager.Models;

namespace ProjectManager
{
    public class Startup
    {
        public static void Main()
        {
            var database = new Database();
            var modelsFactory = new ModelsFactory();

            var commandFactory = new CommandFactory(database, modelsFactory);

            var cmdCpu = new CommandProcessor(commandFactory);
            var consoleReader = new ConsoleReader();
            var consoleLogger = new ConsoleLogger();
            var filelogger = new FileLogger();

            var engine = new Engine(consoleReader, filelogger, consoleLogger, cmdCpu);

            engine.Start();
        }
    }
}
