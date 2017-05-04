using Moq;
using NUnit.Framework;
using ProjectManager.CLI.Core;
using ProjectManager.CLI.Core.Conctracts;
using ProjectManager.CLI.Core.Contracts;

namespace ProjectManager.Tests
{
    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void Start_Should_ReadCommand()
        {
            var readerMocked = new Mock<IReader>();
            var fileLogger = new Mock<IFileLogger>();
            var consoleLogger = new Mock<ILogger>();
            var parser = new Mock<IParser>();

            readerMocked.Setup(m => m.ReadLine()).Returns("Exit");

            var engine = new Engine(readerMocked.Object, fileLogger.Object, consoleLogger.Object, parser.Object);

            engine.Start();

            readerMocked.Verify(m => m.ReadLine(), Times.Once);
        }

        [Test]
        public void Start_ShouldWrite_CorrectMessage_WhenPassed_ExitCommand()
        {
            var readerMocked = new Mock<IReader>();
            var fileLogger = new Mock<IFileLogger>();
            var consoleLogger = new Mock<ILogger>();
            var parser = new Mock<IParser>();

            readerMocked.Setup(m => m.ReadLine()).Returns("Exit");

            var engine = new Engine(readerMocked.Object, fileLogger.Object, consoleLogger.Object, parser.Object);

            engine.Start();

            consoleLogger.Verify(m => m.Log("Program terminated."), Times.Once);
        }

        [Test]
        public void Start_ShouldWrite_CorrectExecutionCommandMessage()
        {
            const string fullCommand = "CreateProject DeathStar 2016-1-1 2018-05-04 Active";
            const string commandResult = "Successfully created a new project!";
            const string terminationCommand = "Exit";

            var readerMocked = new Mock<IReader>();
            var fileLogger = new Mock<IFileLogger>();
            var consoleLogger = new Mock<ILogger>();
            var parser = new Mock<IParser>();

            parser.Setup(m => m.ProcessCommand(It.IsAny<string>())).Returns(commandResult);

            readerMocked.SetupSequence(m => m.ReadLine())
                .Returns(fullCommand)
                .Returns(terminationCommand);

            var engine = new Engine(readerMocked.Object, fileLogger.Object, consoleLogger.Object, parser.Object);

            engine.Start();

            consoleLogger.Verify(m => m.Log(commandResult), Times.Once);
        }

        [Test]
        public void Start_ShouldWrite_ExecutionMessage_WhenUserValidationExeptionOccurs()
        {
            const string invalidCommand = "asasf";
            const string terminationCommand = "Exit";
            const string errorMessage = " - Error: The passed command is not valid!";

            var readerMocked = new Mock<IReader>();
            var fileLogger = new Mock<IFileLogger>();
            var consoleLogger = new Mock<ILogger>();
            var parser = new Mock<IParser>();

            parser.Setup(m => m.ProcessCommand(It.IsAny<string>()))
                .Returns(errorMessage);

            readerMocked.SetupSequence(m => m.ReadLine())
                .Returns(invalidCommand)
                .Returns(terminationCommand);

            var engine = new Engine(readerMocked.Object, fileLogger.Object, consoleLogger.Object, parser.Object);

            engine.Start();

            consoleLogger.Verify(m => m.Log(errorMessage), Times.Once);
        }

        [Test]
        public void Start_Logs_ExceptionMessageWhenGenericErrorOccurs()
        {
            const string invalidCommand = "CreateTask -1 0 BuildTheStar Pending";
            const string terminationCommand = "Exit";
            const string errorMessage = "ERROR - Index was out of range. Must be non-negative and less than the size of the collection.\nParameter name: index";

            var readerMocked = new Mock<IReader>();
            var fileLogger = new Mock<IFileLogger>();
            var consoleLogger = new Mock<ILogger>();
            var parser = new Mock<IParser>();

            parser.Setup(m => m.ProcessCommand(It.IsAny<string>()))
                .Returns(errorMessage);

            readerMocked.SetupSequence(m => m.ReadLine())
                .Returns(invalidCommand)
                .Returns(terminationCommand);

            var engine = new Engine(readerMocked.Object, fileLogger.Object, consoleLogger.Object, parser.Object);

            engine.Start();

            consoleLogger.Verify(m => m.Log(errorMessage), Times.Once);
        }

        [Test]
        public void Start_WritesAString_ThatContainsSOmethingHappend_WhenGenericExceptionOccurs()
        {
            const string invalidCommand = "CreateTask -1 0 BuildTheStar Pending";
            const string terminationCommand = "Exit";
            const string errorMessage = "Opps, something happened. :(";

            var readerMocked = new Mock<IReader>();
            var fileLogger = new Mock<IFileLogger>();
            var consoleLogger = new Mock<ILogger>();
            var parser = new Mock<IParser>();

            parser.Setup(m => m.ProcessCommand(It.IsAny<string>()))
                .Returns(errorMessage);

            readerMocked.SetupSequence(m => m.ReadLine())
                .Returns(invalidCommand)
                .Returns(terminationCommand);

            var engine = new Engine(readerMocked.Object, fileLogger.Object, consoleLogger.Object, parser.Object);

            engine.Start();

            consoleLogger.Verify(m => m.Log(errorMessage), Times.Once);
        }
    }
}
