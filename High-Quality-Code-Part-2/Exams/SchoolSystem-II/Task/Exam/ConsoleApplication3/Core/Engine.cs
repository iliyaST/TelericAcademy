namespace SchoolSystem.CLI.Core
{
    using System;
    using System.Collections.Generic;
    using Core.Contracts;
    using Core.Providers;
    using Models;

    public class Engine : IEngine
    {
        private static IEngine instanceHolder = new Engine();

        private Engine()
        {
            this.Reader = new ConsoleReaderProvider();
            this.Parser = new CommandParserProvider();
            this.Writer = new ConsoleWriterProvider();

            this.Teachers = new Dictionary<int, Teacher>();
            this.Students = new Dictionary<int, Student>();
        }

        public static IEngine Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public IReader Reader { get; set; }

        public IParser Parser { get; set; }

        public IWriter Writer { get; set; }

        public Dictionary<int, Teacher> Teachers { get; set; }

        public Dictionary<int, Student> Students { get; set; }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var fullCommandName = this.Reader.ReadLine();
                    if (fullCommandName == "End")
                    {
                        break;
                    }

                    var command = this.Parser.ParseCommand(fullCommandName);
                    var commandParameters = this.Parser.GetCommandParameters(fullCommandName);

                    this.Writer.WriteLine(command.Execute(commandParameters));
                }
                catch (Exception ex)
                {
                    this.Writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
