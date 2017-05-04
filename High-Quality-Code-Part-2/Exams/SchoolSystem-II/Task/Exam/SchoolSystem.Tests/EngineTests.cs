namespace SchoolSystem.Tests
{
    using CLI.Core;
    using CLI.Core.Contracts;
    using Moq;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void Constructor_ShouldThrow_Exception_WhenPRoviderIsNotProvider()
        {
            var parser = new Mock<IParser>();
            var writer = new Mock<IWriter>();
            Assert.Throws<ArgumentNullException>(() =>
            new Engine(null, parser.Object, writer.Object));
        }

        [Test]
        public void Constructor_ShouldThrow_Exception_WhenPRoviderIsNotProvider_Parser()
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            Assert.Throws<ArgumentNullException>(() =>
            new Engine(reader.Object, null, writer.Object));
        }

        [Test]
        public void Constructor_ShouldThrow_Exception_WhenPRoviderIsNotProvider_Writer()
        {
            var reader = new Mock<IReader>();
            var parser = new Mock<IParser>();

            Assert.Throws<ArgumentNullException>(() =>
            new Engine(reader.Object, parser.Object, null));
        }

        [Test]
        public void Constructor_Should_Not_ThrowException_WhenValidParametersAreInputed()
        {
            var reader = new Mock<IReader>();
            var parser = new Mock<IParser>();
            var writer = new Mock<IWriter>();

            Assert.DoesNotThrow(() => new Engine(reader.Object, parser.Object,
                writer.Object));
        }

        [Test]
        public void Constructor_InitializerCorretly_ListsInside()
        {
            var reader = new Mock<IReader>();
            var parser = new Mock<IParser>();
            var writer = new Mock<IWriter>();

            var engine = new Engine(reader.Object, parser.Object, writer.Object);

            Assert.AreEqual(Engine.Students.Count, 0);
            Assert.AreEqual(Engine.Teachers.Count, 0);
        }
    }
}
