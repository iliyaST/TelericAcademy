namespace MatrixFullfillmentTests
{
    using NUnit.Framework;
    using MatrixFullFillment;
    using Moq;
    using MatrixFullFIllment.Contracts;

    [TestFixture]
    public class ExecuteTests
    {
        [Test]
        [TestCase("0")]
        [TestCase("101")]
        [TestCase("-1")]
        public void Entering_WrongMatrixDimensions_ShouldLogInConsole_CorrectMessage(string dimensions)
        {
            var loggerMock = new Mock<ILogger>();
            var engine = new Engine(dimensions, loggerMock.Object);

            engine.Execute();

            loggerMock.Verify(
                x => x.Log(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        [TestCase("10")]
        public void Entering_CorrectDimensions_ShouldCreateMatrix_WithCorrectParameters_10(string dimensions)
        {
            var loggerMock = new Mock<ILogger>();
            var engine = new Engine(dimensions, loggerMock.Object);

            engine.Execute();

            Assert.AreEqual("10", engine.MatrixDimensions);
        }

        [Test]
        [TestCase("99")]
        public void Entering_CorrectDimensions_ShouldCreateMatrix_WithCorrectParameters_100(string dimensions)
        {
            var loggerMock = new Mock<ILogger>();
            var engine = new Engine(dimensions, loggerMock.Object);

            engine.Execute();

            Assert.AreEqual("99", engine.MatrixDimensions);
        }

        [Test]
        [TestCase("1")]
        public void Entering_CorrectDimensions_ShouldCreateMatrix_WithCorrectParameters_1(string dimensions)
        {
            var loggerMock = new Mock<ILogger>();
            var engine = new Engine(dimensions, loggerMock.Object);

            engine.Execute();

            Assert.AreEqual("1", engine.MatrixDimensions);
        }

        [Test]
        public void Entering_CorrectDimensions_ShouldFillTheMatrix_Correctly()
        {
            var loggerMock = new Mock<ILogger>();
            var engine = new Engine("3", loggerMock.Object);

            var resultMatrix = engine.Execute();

            Assert.AreEqual(1, resultMatrix[0, 0]);
            Assert.AreEqual(7, resultMatrix[0, 1]);
            Assert.AreEqual(8, resultMatrix[0, 2]);
            Assert.AreEqual(6, resultMatrix[1, 0]);
            Assert.AreEqual(2, resultMatrix[1, 1]);
            Assert.AreEqual(9, resultMatrix[1, 2]);
            Assert.AreEqual(5, resultMatrix[2, 0]);
            Assert.AreEqual(4, resultMatrix[2, 1]);
            Assert.AreEqual(3, resultMatrix[2, 2]);
        }
    }
}
