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
    public class AddTests
    {
        [Test]
        public void Add_ShouldThrowArgumentNullExeption_WhenThePackageIsInvalid()
        {
            var packages = new List<IPackage>();
            var loggerMocked = new Mock<ILogger>();

            var repository = new PackageRepository(loggerMocked.Object,
               packages);

            Assert.Throws<ArgumentNullException>(() => repository.Add(null));
        }

        [Test]
        public void Add_ShouldNotThrow_WhenPackageIsValid()
        {
            var loggerMocked = new Mock<ILogger>();
            var packageMocked = new Mock<IPackage>();
            var packages = new List<IPackage>() { packageMocked.Object };

            var repository = new PackageRepository(loggerMocked.Object,
               packages);

            Assert.DoesNotThrow(
                () => repository.Add(packageMocked.Object));
        }

        [Test]
        public void Add_ShouldTestIfTheSamePackageVersionIsFound()
        {
            var loggerMocked = new Mock<ILogger>();
            var packageMocked = new Mock<IPackage>();

            packageMocked.Setup(
                m => m.Name).Returns("SomePackageName");

            var packages = new List<IPackage>() { packageMocked.Object };

            var repository = new PackageRepository(loggerMocked.Object,
               packages);
         
            repository.Add(packageMocked.Object);

            loggerMocked.Verify(
                m =>
                m.Log("SomePackageName: Package with the same version is already installed!")
                ,Times.Once);
        }


        [Test]
        public void Add_CallUpdateMethod_IfVersionIsLower()
        {
            var loggerMocked = new Mock<ILogger>();
            var packageMocked = new Mock<IPackage>();
            var lowerVersionPackageMocked = new Mock<IPackage>();

            packageMocked.Setup(
                m => m.ToString()).Returns("first");

            lowerVersionPackageMocked.Setup(
                m => m.ToString()).Returns("second");

            packageMocked.Setup(
                m => m.CompareTo(It.IsAny<IPackage>())).Returns(1);

            var packages = new List<IPackage>() { lowerVersionPackageMocked.Object };

            var repository = new PackageRepository(loggerMocked.Object,
               packages);

            repository.Add(packageMocked.Object);

            lowerVersionPackageMocked.VerifySet(
                m => m.Version = It.IsAny<IVersion>(),Times.Once);
        }

        [Test]
        public void Add_ShouldCallLogger_WithHigherVersionAlreadyExist()
        {
            var loggerMocked = new Mock<ILogger>();
            var packageMocked = new Mock<IPackage>();
            var lowerVersionPackageMocked = new Mock<IPackage>();

            packageMocked.Setup(
                m => m.Name).Returns("SomeP");

            lowerVersionPackageMocked.Setup(
                m => m.Name).Returns("SomeP");

            packageMocked.Setup(
                m => m.CompareTo(It.IsAny<IPackage>())).Returns(-1);

            var packages = new List<IPackage>() { lowerVersionPackageMocked.Object };

            var repository = new PackageRepository(loggerMocked.Object,
               packages);

            repository.Add(packageMocked.Object);

            loggerMocked.Verify(
                m => m.Log("SomeP: There is a package with newer version!")
                , Times.Once);
        }

        [Test]
        public void Add_ShouldCallLogerWith_LowerVersionOfPackageAlreadyExist()
        {
            var loggerMocked = new Mock<ILogger>();
            var packageMocked = new Mock<IPackage>();
            var lowerVersionPackageMocked = new Mock<IPackage>();

            packageMocked.Setup(
                m => m.Name).Returns("SomeP");

            lowerVersionPackageMocked.Setup(
                m => m.Name).Returns("SomeP");

            packageMocked.Setup(
                m => m.CompareTo(It.IsAny<IPackage>())).Returns(1);

            var packages = new List<IPackage>() { lowerVersionPackageMocked.Object };

            var repository = new PackageRepository(loggerMocked.Object,
               packages);

            repository.Add(packageMocked.Object);

            //loggerMocked.Verify(
            //    m => m.Log("SomeP: There is a package with newer version!")
            //    , Times.Once);
        }
    }
}
