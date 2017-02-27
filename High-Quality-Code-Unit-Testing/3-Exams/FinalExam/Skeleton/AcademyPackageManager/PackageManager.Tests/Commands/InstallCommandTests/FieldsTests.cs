using Moq;
using NUnit.Framework;
using PackageManager.Commands;
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
    public class FieldsTests
    {
        [Test]
        public void Constructor_ShouldSet_AppropriatePassedValue_Installer()
        {
            var installerMocked = new Mock<IInstaller<IPackage>>();
            var packageMocked = new Mock<IPackage>();

            var installCommand = new InstallCommandExtended(installerMocked.Object,
                packageMocked.Object);

            Assert.AreEqual(installerMocked.Object,
                installCommand.GetInstaller);
        }

        [Test]
        public void Constructor_ShouldSet_AppropriatePassedValue_Package()
        {
            var installerMocked = new Mock<IInstaller<IPackage>>();
            var packageMocked = new Mock<IPackage>();

            var installCommand = new InstallCommandExtended(installerMocked.Object,
                packageMocked.Object);

            Assert.AreEqual(packageMocked.Object,
                installCommand.GetPackage);
        }
    }
}
