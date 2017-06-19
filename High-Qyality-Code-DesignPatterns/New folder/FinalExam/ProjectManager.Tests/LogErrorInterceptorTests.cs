using System;
using Moq;
using Ninject.Extensions.Interception;
using NUnit.Framework;
using ProjectManager.ConsoleClient.Interceptors;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;

namespace ProjectManager.Tests
{
    [TestFixture]
    public class LogErrorInterceptorTests
    {
        [Test]
        public void Intercept_ShouldCallLoggerWhenThereIsGenericException()
        {
            const string InvalidMessage = "Invalid Command";

            var loggerMocked = new Mock<ILogger>();

            var interceptor = new LogErrorInterceptor(loggerMocked.Object);

            var invocationMocked = new Mock<IInvocation>();

            invocationMocked.Setup(x => x.Proceed())
                .Throws(new Exception(InvalidMessage));

            interceptor.Intercept(invocationMocked.Object);

            loggerMocked.Verify(x => x.Error(InvalidMessage), Times.Once);
        }

        [Test]
        public void Intercept_ShouldCallLogger_WhenThereIsUserExceptionThrown()
        {
            const string InvalidUserCommandMessage = "Invalid Command";           

            var loggerMocked = new Mock<ILogger>();

            var interceptor = new LogErrorInterceptor(loggerMocked.Object);

            var invocationMocked = new Mock<IInvocation>();

            invocationMocked.Setup(x => x.Proceed())
                .Throws(new UserValidationException(InvalidUserCommandMessage));

            interceptor.Intercept(invocationMocked.Object);

            loggerMocked.Verify(x => x.Error(InvalidUserCommandMessage), Times.Once);
        }

        [Test]
        public void Intercept_ShouldCallLoggerZeroTimesWhenThereIsNoException()
        {
            var loggerMocked = new Mock<ILogger>();

            var interceptor = new LogErrorInterceptor(loggerMocked.Object);

            var invocationMocked = new Mock<IInvocation>();

            interceptor.Intercept(invocationMocked.Object);

            loggerMocked.Verify(x => x.Error(It.IsAny<string>()), Times.Exactly(0));
        }
    }
}
