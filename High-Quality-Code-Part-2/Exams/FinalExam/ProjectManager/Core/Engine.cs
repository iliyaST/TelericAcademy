using Bytes2you.Validation;
using Pesho.Core.Contracts;
using ProjectManager.Common;
using ProjectManager.Common.Exceptions;
using System;

namespace ProjectManager
{
    public class Engine
    {
        private const string TerminateCommandMessage = "Program terminated.";
        private IFileLogger filelogger;
        private ILogger consoleLogger;
        private IReader consoleReader;
        private IParser parser;


        public Engine(IReader reader, IFileLogger filelogger, ILogger consoleLogger, IParser parser)
        {
            // validate clauses
            Guard.WhenArgument(filelogger, "Engine Logger provider").IsNull().Throw();

            Guard.WhenArgument(parser, "Engine Processor provider").IsNull().Throw();

            this.consoleReader = reader;
            this.filelogger = filelogger;
            this.consoleLogger = consoleLogger;
            this.parser = parser;
        }

        public void Start()
        {
            while (true)
            {
                var command = consoleReader.ReadLine();

                if (command.ToLower() == "exit")
                {
                    this.consoleLogger.Log(TerminateCommandMessage);
                    break;
                }

                try
                {
                    var executionResult = this.parser.ProcessCommand(command);
                    this.consoleLogger.Log(executionResult);
                }
                catch (UserValidationException ex)
                {
                    this.consoleLogger.Log(ex.Message);
                }
                catch (Exception ex)
                {
                    this.consoleLogger.Log("Opps, something happened. :(");
                    this.filelogger.Error(ex.Message);
                }
            }
        }
    }
}
