using Moq;
using NUnit.Framework;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    [TestFixture]
    public class UpdateTests
    {
        [Test]
        public void Update_ShouldThrowArgumentNullExeption_WhenThePackageIsInvalid()
        {
            var packages = new List<IPackage>();
            var loggerMocked = new Mock<ILogger>();

            var repository = new PackageRepository(loggerMocked.Object,
               packages);

            Assert.Throws<ArgumentNullException>(() => repository.Update(null));
        }

        [Test]
        public void Update_ShouldNotThrow_WhenPackageIsValid()
        {
            var loggerMocked = new Mock<ILogger>();
            var packageMocked = new Mock<IPackage>();
            var packages = new List<IPackage>() { packageMocked.Object };

            var repository = new PackageRepository(loggerMocked.Object,
               packages);

            Assert.DoesNotThrow(
                () => repository.Update(packageMocked.Object));
        }

        [Test]
        public void Update_ShouldThrowArgumentNullExeption_IfPackageWasntFound()
        {
            var loggerMocked = new Mock<ILogger>();
            var packageMocked = new Mock<IPackage>();
            var packages = new List<IPackage>() { };

            var repository = new PackageRepository(loggerMocked.Object,
               packages);

            Assert.Throws<ArgumentNullException>(
                () => repository.Update(packageMocked.Object));
        }

        [Test]
        public void Update_ShouldSuccesfullyUpdate_WhenLowerVersionFound()
        {
            var loggerMocked = new Mock<ILogger>();
            var packageMocked = new Mock<IPackage>();
            var packages = new List<IPackage>() {packageMocked.Object };

            packageMocked.Setup(
                m => m.Name).Returns("ba");

            packageMocked.Setup(
                m => m.CompareTo(It.IsAny<IPackage>())).Returns(1);

            var repository = new PackageRepository(loggerMocked.Object,
               packages);

           Assert.IsTrue(repository.Update(packageMocked.Object));
        }

        [Test]
        public void Update_ShouldThrowArgumentExeption_IfFoundHigherVersion()
        {
            var loggerMocked = new Mock<ILogger>();
            var packageMocked = new Mock<IPackage>();
            var packages = new List<IPackage>() { packageMocked.Object };

            packageMocked.Setup(
                m => m.Name).Returns("ba");

            packageMocked.Setup(
                m => m.CompareTo(It.IsAny<IPackage>())).Returns(-1);

            var repository = new PackageRepository(loggerMocked.Object,
               packages);

            Assert.Throws<ArgumentException>(
                ()=>repository.Update(packageMocked.Object));

            loggerMocked.Verify(
                m => m.Log("ba: The package has higher version than you are trying to install!")
                , Times.Once);
        }

        [Test]
        public void Update_ShouldReturnFalseIfVersions_AreTheSame()
        {
            var loggerMocked = new Mock<ILogger>();
            var packageMocked = new Mock<IPackage>();
            var packages = new List<IPackage>() { packageMocked.Object };

            packageMocked.Setup(
                m => m.Name).Returns("ba");

            packageMocked.Setup(
                m => m.CompareTo(It.IsAny<IPackage>())).Returns(0);

            var repository = new PackageRepository(loggerMocked.Object,
               packages);

            Assert.IsFalse(repository.Update(packageMocked.Object));

            loggerMocked.Verify(
                m => m.Log("ba: Package with the same version is already installed!")
                ,Times.Once);
        }
    }
}
