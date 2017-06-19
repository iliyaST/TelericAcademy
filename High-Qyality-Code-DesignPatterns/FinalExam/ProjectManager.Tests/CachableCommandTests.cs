using Moq;
using NUnit.Framework;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Decorators;
using ProjectManager.Framework.Services;
using System.Collections.Generic;

namespace ProjectManager.Tests
{
    [TestFixture]
    public class CachableCommandTests
    {
        [Test]
        public void Execute_ShouldCallGetCatchingZeroTimesWhenMethodIsCalledForTheFirstTime()
        {
            var commandMocked = new Mock<ICommand>();
            var serviceMocked = new Mock<ICachingService>();

            var command = new CacheableCommand(commandMocked.Object,serviceMocked.Object);

            command.Execute(new List<string>());

            serviceMocked.Verify(x => x.GetCacheValue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(0));
        }

        [Test]
        public void Execute_ShouldCallGetCatchingIfCommandIsCalledNotForFirstTimeAndItsNotExpired()
        {
            var commandMocked = new Mock<ICommand>();
            var serviceMocked = new Mock<ICachingService>();

            serviceMocked.Setup(x => x.IsExpired).Returns(false);

            var command = new CacheableCommand(commandMocked.Object, serviceMocked.Object);

            command.Execute(new List<string>());

            command.Execute(new List<string>());

            serviceMocked.Verify(x => x.GetCacheValue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(1));
        }

        [Test]
        public void Execute_ShouldCallZeroTimesIfItsExpiredAndNotFirstTime()
        {
            var commandMocked = new Mock<ICommand>();
            var serviceMocked = new Mock<ICachingService>();

            serviceMocked.Setup(x => x.IsExpired).Returns(true);

            var command = new CacheableCommand(commandMocked.Object, serviceMocked.Object);

            command.Execute(new List<string>());

            command.Execute(new List<string>());

            serviceMocked.Verify(x => x.GetCacheValue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(0));
        }
    }
}
