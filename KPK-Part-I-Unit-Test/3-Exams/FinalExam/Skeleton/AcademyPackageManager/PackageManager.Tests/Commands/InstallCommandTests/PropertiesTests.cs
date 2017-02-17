using Moq;
using NUnit.Framework;
using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [Test]
        public void Constructor_ShouldSet_AppropriatePassedValue_installerOperetionShouldBeSetToInstall()
        {
            var installerMocked = new Mock<IInstaller<IPackage>>();
            var packageMocked = new Mock<IPackage>();

            var installCommand = new InstallCommand(installerMocked.Object,
                packageMocked.Object);
           
            installerMocked.VerifySet(
                m => m.Operation = InstallerOperation.Install, Times.Once);
        }
    }
}
