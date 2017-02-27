using Moq;
using NUnit.Framework;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Tests.Commands.InstallCommandTests.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    public class ExecuteTests
    {
        [Test]
        public void Execute_ShouldCallPerformingOperation()
        {
            var installerMocked = new Mock<IInstaller<IPackage>>();
            var packageMocked = new Mock<IPackage>();

            var installCommand = new InstallCommandExtended(installerMocked.Object,
                packageMocked.Object);

            installCommand.Execute();

            installerMocked.Verify(
                m => m.PerformOperation(It.IsAny<IPackage>()),
                Times.Once);
        }
    }
}
