namespace SchoolSystem.CLI
{
    using Core.Providers;
    using SchoolSystem.CLI.Core;

    public class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReaderProvider();
            var parser = new CommandParserProvider();
            var writer = new ConsoleWriterProvider();

            var engine = new Engine(reader, parser, writer);

            engine.Start();
        }
    }
}
