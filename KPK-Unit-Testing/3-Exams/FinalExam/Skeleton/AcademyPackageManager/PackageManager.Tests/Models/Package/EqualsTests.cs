using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.ModelsPackage
{
    [TestFixture]
    public class EqualsTests
    {
        [Test]
        public void Equals_ShouldThrowArgumentNullExeption_WhenOtherIsInvalid()
        {
            var someVersionMocked = new Mock<IVersion>();
            var dependenciesMocked = new Mock<ICollection<IPackage>>();

            var package = new Package(
                "The_Dictator", someVersionMocked.Object, dependenciesMocked.Object);

            Assert.Throws<ArgumentNullException>(
                ()=>package.Equals(null));
        }

        [Test]
        public void Equals_ShouldNotThrowArgumentNullExeption_WhenOtherIsValid()
        {
            var someVersionMocked = new Mock<IVersion>();
            var dependenciesMocked = new Mock<ICollection<IPackage>>();
            var otherPackageMocked = new Mock<IPackage>();
            var otherPackageVersionMocked = new Mock<IVersion>();

            otherPackageMocked.Setup(
                m => m.Version).Returns(otherPackageVersionMocked.Object);

            var package = new Package(
                "The_Dictator", someVersionMocked.Object, dependenciesMocked.Object);

            Assert.DoesNotThrow(
                () => package.Equals(otherPackageMocked.Object));
        }

        [Test]
        public void Equals_ShouldThrowArgumentExeption_WhenPassedObject_IsNotAPackage()
        {
            var someVersionMocked = new Mock<IVersion>();
            var dependenciesMocked = new Mock<ICollection<IPackage>>();
            var obj = new object();
        
            var package = new Package(
                "The_Dictator", someVersionMocked.Object, dependenciesMocked.Object);

            var ex = Assert.Throws<ArgumentException>(
                () => package.Equals(obj));

            StringAssert.Contains("IPackage", ex.Message);
        }

        [Test]
        public void Equals_TestForPackagePassed_ToBeEqualToPackage()
        {
            var someVersionMocked = new Mock<IVersion>();
            var dependenciesMocked = new Mock<ICollection<IPackage>>();
            var otherPackageMocked = new Mock<IPackage>();
            var otherPackageVersionMocked = new Mock<IVersion>();

            otherPackageMocked.Setup(
                m => m.Name).Returns("The_Dictator");

            otherPackageMocked.Setup(
                m => m.Version).Returns(otherPackageVersionMocked.Object);

            var package = new Package(
                "The_Dictator", someVersionMocked.Object, dependenciesMocked.Object);

            Assert.IsTrue(package.Equals(otherPackageMocked.Object));
        }

        [Test]
        public void Equals_TestForPackagePassed_ToBeNotEqualToPackage()
        {
            var someVersionMocked = new Mock<IVersion>();
            var dependenciesMocked = new Mock<ICollection<IPackage>>();
            var otherPackageMocked = new Mock<IPackage>();
            var otherPackageVersionMocked = new Mock<IVersion>();

            otherPackageMocked.Setup(
                m => m.Name).Returns("Different_Koch_Name");

            otherPackageMocked.Setup(
                m => m.Version).Returns(otherPackageVersionMocked.Object);

            var package = new Package(
                "The_Dictator", someVersionMocked.Object, dependenciesMocked.Object);

            Assert.IsFalse(package.Equals(otherPackageMocked.Object));
        }
    }
}
