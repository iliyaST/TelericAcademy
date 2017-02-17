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

namespace PackageManager.Tests.Core.PackageInstallerTests
{
    [TestFixture]
    public class PerformOperationTests
    {
        [Test]
        public void PerformOperation_ShouldCall2TimesDownloadAndOneTimeRemoveWithEmptyList()
        {
            var downloaderMocked = new Mock<IDownloader>();
            var projectMocked = new Mock<IProject>();
            var package = new Mock<IPackage>();

            package.Setup(
                m => m.Dependencies).Returns(new List<IPackage>());

            projectMocked.Setup(
                m => m.PackageRepository.GetAll()).Returns(
                new List<IPackage>() { package.Object });

            var installer = new PackageInstaller(downloaderMocked.Object,
                projectMocked.Object);

            downloaderMocked.Verify(
                m => m.Remove(It.IsAny<string>()),
                Times.Once);

            downloaderMocked.Verify(
                m => m.Download(It.IsAny<string>())
                ,Times.Exactly(2));
        }

        [Test]
        public void PerformOperation_ShouldDoubleTheCallsForDownloadAndRemove_ForEveryDependency()
        {
            var downloaderMocked = new Mock<IDownloader>();
            var projectMocked = new Mock<IProject>();
            var package = new Mock<IPackage>();
            var someEmptyPackage = new Mock<IPackage>();

            someEmptyPackage.Setup(
                m => m.Dependencies).Returns(new List<IPackage>());

            package.Setup(
                m => m.Dependencies).Returns(new List<IPackage>() {
                someEmptyPackage.Object});

            projectMocked.Setup(
                m => m.PackageRepository.GetAll()).Returns(
                new List<IPackage>() { package.Object });

            var installer = new PackageInstaller(downloaderMocked.Object,
                projectMocked.Object);

            downloaderMocked.Verify(
                m => m.Remove(It.IsAny<string>()),
                Times.Exactly(2));

            downloaderMocked.Verify(
                m => m.Download(It.IsAny<string>())
                , Times.Exactly(4));
        }
    }
}
