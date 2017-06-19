﻿using ProjectManager.Framework.Core.Common.Contracts;

namespace ProjectManager.Framework.Core
{
    public class Engine : IEngine
    {
        private IProcessor processor;
        private IReader reader;
        private IWriter writer;

        public Engine(IProcessor processor, IReader reader, IWriter writer)
        {
            this.processor = processor;
            this.reader = reader;
            this.writer = writer;
        }      

        public void Start()
        {
            for (;;)
            {
                var commandLine = this.reader.ReadLine();

                if (commandLine.ToLower() == "exit")
                {
                    this.writer.WriteLine("Program terminated.");
                    break;
                }

                this.processor.ProcessCommand(commandLine);
            }
        }
    }
}
