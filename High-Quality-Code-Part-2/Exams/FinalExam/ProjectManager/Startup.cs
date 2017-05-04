using ProjectManager.CLI.Core;
using ProjectManager.CLI.Core.Commands;
using ProjectManager.CLI.Core.Providers;
using ProjectManager.CLI.Data;

namespace ProjectManager.CLI
{
    public class Startup
    {
        public static void Main()
        {
            var database = new Database();
            var modelsFactory = new ModelsFactory();

            var commandFactory = new CommandsFactory(database, modelsFactory);

            var parser = new CommandParser(commandFactory);
            var consoleReader = new ConsoleReader();
            var consoleLogger = new ConsoleLogger();
            var filelogger = new FileLogger();

            var engine = new Engine(consoleReader, filelogger, consoleLogger, parser);

            engine.Start();
        }
    }
}
