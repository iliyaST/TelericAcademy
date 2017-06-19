namespace SchoolSystem.CLI.Core
{
    using System;
    using System.Collections.Generic;
    using Core.Contracts;
    using Core.Providers;
    using Models;

    public class Engine
    {
        public Engine(IReader reader, IParser parser, IWriter writer)
        {
            this.Reader = 
                reader;
            this.Parser =
                parser;
            this.Writer = writer;

            Teachers = new Dictionary<int, Teacher>();
            Students = 
                new Dictionary<int, Student>();
        }

        public static 
            Dictionary<int, Teacher> Teachers { get; set; }

        public static Dictionary<int, Student> Students { get; set; }

        public IReader Reader { get; set; }

        public IParser Parser { get; set; }

        public IWriter Writer { get; set; }

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
