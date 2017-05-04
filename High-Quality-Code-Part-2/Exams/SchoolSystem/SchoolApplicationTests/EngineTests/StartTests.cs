namespace SchoolApplicationTests
{
    using ConsoleApplication3.Models.Contracts;
    using Moq;
    using NUnit.Framework;
    using School.Core;
    using School.Models.Contracts;
    using System;

    [TestFixture]
    public class StartTests
    {

        [Test]
        public void Constructor_Should_Throw_ArgumentNullExeption_WhenReader_IsNull()
        {
            var writer = new Mock<IWriter>();
            Assert.Throws<ArgumentNullException>(() => new Engine(null, writer.Object));
        }

        [Test]
        public void Constructor_Should_Throw_ArgumentNullExeption_WhenWriter_IsNull()
        {
            var reader = new Mock<IReader>();
            Assert.Throws<ArgumentNullException>(() => new Engine(reader.Object, null));
        }

        [Test]
        public void Start_Should_EndTheProgram_When_End_IsInserted()
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var terminateCommand = "End";

            reader.Setup(command => command.ReadLine()).Returns(terminateCommand);

            var engine = new Engine(reader.Object, writer.Object);

            engine.Start();

            writer.Verify(method => method.WriteLine(It.IsAny<string>()), Times.Exactly(0));
            writer.Verify(method => method.Write(It.IsAny<string>()), Times.Exactly(0));
        }

        [Test]
        public void Start_ShouldPrintOnce_When_ValidCommandIsInputed_And_TerminateCommandAfter_ToBreakLoop()
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();

            var command = "CreateStudent Pesho Petrov 10";

            reader.Setup(m => m.ReadLine())
                 .Returns(() => command)
                 .Callback(() => command = "End");

            var engine = new Engine(reader.Object, writer.Object);

            engine.Start();

            var result = "A new student with name Pesho Petrov, grade Tenth and ID 0 was created.";
            writer.Verify(m => m.WriteLine(result), Times.Once);
        }

        [Test]
        public void Start_Should_Print_InvalidMessage_WhenInvalidCommandAndTerminateCommandAfter()
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
                        
            var command = "Invalid Command!";

            reader.Setup(m => m.ReadLine())
                .Returns(() => command)
                .Callback(() =>
                {
                    command = "End";
                });

            var engine = new Engine(reader.Object, writer.Object);

            engine.Start();

            writer.Verify(m => m.WriteLine("Invalid Command!"), Times.Once);
        }
    }
}
