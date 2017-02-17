using Moq;
using NUnit.Framework;
using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.CorePackageInstaller
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void PackageInstaller_ShouldTestForRestoringPckages_WhenTheObjectIsConstructed_ShouldTestForDependencies_InTheProject()
        {
            var downloaderMocked = new Mock<IDownloader>();
            var projectMocked = new Mock<IProject>();
            var package = new Mock<IPackage>();

            package.Setup(
                m => m.Dependencies).Returns(new List<IPackage>());

            projectMocked.Setup(
                m => m.PackageRepository.GetAll()).Returns(
                new List<IPackage>() {package.Object });

            var installer = new PackageInstaller(downloaderMocked.Object,
                projectMocked.Object);
        }
    }
}
