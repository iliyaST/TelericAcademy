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
    public class DeleteTests
    {
        [Test]
        public void Delete_ShouldThrow_ArgumentNullExeption_WhenInvalidPackageWasPassed()
        {
            var packages = new List<IPackage>();
            var loggerMocked = new Mock<ILogger>();

            var repository = new PackageRepository(loggerMocked.Object,
               packages);

            Assert.Throws<ArgumentNullException>(
                () => repository.Delete(null));
        }

        [Test]
        public void Delete_ShouldNotThrow_WhenPackageIsValid()
        {
            var loggerMocked = new Mock<ILogger>();
            var packageMocked = new Mock<IPackage>();
            var packages = new List<IPackage>() { packageMocked.Object };

            packageMocked.Setup(
                m => m.Equals(It.IsAny<object>())).Returns(true);

            packageMocked.Setup(
                m => m.Dependencies).Returns(new List<IPackage>() { });

            var repository = new PackageRepository(loggerMocked.Object,
               packages);

            Assert.DoesNotThrow(
                () => repository.Delete(packageMocked.Object));
        }

        [Test]
        public void Delete_ShouldThrowArgumentNullExeption_IfPackageWasntFound()
        {
            var loggerMocked = new Mock<ILogger>();
            var packageMocked = new Mock<IPackage>();
            var packages = new List<IPackage>() { packageMocked.Object };

            packageMocked.Setup(
                m => m.Equals(It.IsAny<object>())).Returns(false);

            packageMocked.Setup(
                m => m.Name).Returns("Batman");

            packageMocked.Setup(
                m => m.Dependencies).Returns(new List<IPackage>() { });

            var repository = new PackageRepository(loggerMocked.Object,
               packages);

            Assert.Throws<ArgumentNullException>(
                () => repository.Delete(packageMocked.Object));

            loggerMocked.Verify(
                m => m.Log("Batman: The package does not exist!"), Times.Once);
        }

        [Test]
        public void Delete_ShouldCallLoggerIfPackageIsFound_ButDependencyCouldNotBeRemoved()
        {
            var loggerMocked = new Mock<ILogger>();
            var packageMocked = new Mock<IPackage>();
            var packages = new List<IPackage>() { packageMocked.Object };

            packageMocked.Setup(
                m => m.Equals(It.IsAny<object>())).Returns(true);

            packageMocked.Setup(
                m => m.Name).Returns("Batman");

            packageMocked.Setup(
                m => m.Dependencies).Returns(new List<IPackage>() {packageMocked.Object });

            var repository = new PackageRepository(loggerMocked.Object,
               packages);


            repository.Delete(packageMocked.Object);

            loggerMocked.Verify(
                m => m.Log("Batman: The package is a dependency and could not be removed!"), Times.Once);
        }

        [Test]
        public void Delete_ShouldSuccesfully_RemoveThePackage()
        {
            var loggerMocked = new Mock<ILogger>();
            var packageMocked = new Mock<IPackage>();
            var packages = new List<IPackage>() { packageMocked.Object };

            packageMocked.Setup(
                m => m.Equals(It.IsAny<object>())).Returns(true);

            packageMocked.Setup(
                m => m.Name).Returns("Batman");

            packageMocked.Setup(
                m => m.Dependencies).Returns(new List<IPackage>() {  });

            var repository = new PackageRepository(loggerMocked.Object,
               packages);

            //UnComment Works :) 2!!! 
            //Assert.AreEqual(1, packages.Count);

            repository.Delete(packageMocked.Object);

            Assert.AreEqual(0, packages.Count);
        }
    }
}
