namespace School.Core
{
    using ConsoleApplication3.Models.Providers;
    using School.Models.Providers;

    public class Startup
    {
        public static void Main()
        {
            // TODO: abstract at leest 2 mor provider like this one!
            var reader = new ConsoleReaderProvider();
            var writer = new ConsoleWriterProvider();

            var engine = new Engine(reader, writer);

            engine.Start();
        }
    }
}
