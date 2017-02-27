using Moq;
using NUnit.Framework;
using PackageManager.Enums;
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
    public class CompareToTests
    {
        [Test]
        public void CompareTo_ShouldThrow_ArgumentNullExeptionIf_InvalidValueIsPassed()
        {
            var someVersionMocked = new Mock<IVersion>();
            var dependenciesMocked = new Mock<ICollection<IPackage>>();

            var package = new Package(
                "The_Dictator", someVersionMocked.Object, dependenciesMocked.Object);

            var ex = Assert.Throws<ArgumentNullException>(
                () => package.CompareTo(null));

            Assert.AreEqual("The object cannot be null", ex.ParamName);
        }

        [Test]
        public void CompareTo_ShouldNotThrow_ArgumentNullExeptionIf_ValidValueIsPassed()
        {
            var someVersionMocked = new Mock<IVersion>();
            var dependenciesMocked = new Mock<ICollection<IPackage>>();
            var otherMocked = new Mock<IPackage>();
            var otherVersionMocked = new Mock<IVersion>();

            otherMocked.Setup(
                m => m.Name).Returns("The_Dictator");

            otherMocked.Setup(
                m => m.Version).Returns(otherVersionMocked.Object);

            var package = new Package(
                "The_Dictator", someVersionMocked.Object, dependenciesMocked.Object);

            Assert.DoesNotThrow(() => package.CompareTo(otherMocked.Object));
        }

        [Test]
        public void CompareTo_ShouldThrow_ArgumentExeption_WhenPassedPackage_IsNotWithTheSameName()
        {
            var someVersionMocked = new Mock<IVersion>();
            var dependenciesMocked = new Mock<ICollection<IPackage>>();
            var coolerPackageMocked = new Mock<IPackage>();

            coolerPackageMocked.Setup(
                m => m.Name).Returns("BaiGanio");

            var package = new Package(
                "The_Dictator", someVersionMocked.Object, dependenciesMocked.Object);

            var ex = Assert.Throws<ArgumentException>(
                () => package.CompareTo(coolerPackageMocked.Object));
        }

        [Test]
        public void CompareTo_ShouldCheckAndReturnExpectedResult_WhenOtherPackageIsWithHigherVersion()
        {
            var someVersionMocked = new Mock<IVersion>();
            var dependenciesMocked = new Mock<ICollection<IPackage>>();
            var coolerPackageMocked = new Mock<IPackage>();
            var higherVersion = new Mock<IVersion>();

            higherVersion.Setup
                (m => m.Major).Returns(10);

            coolerPackageMocked.Setup(
                m => m.Name).Returns("The_Dictator");

            coolerPackageMocked.Setup(
                m => m.Version).Returns(higherVersion.Object);

            var package = new Package(
                "The_Dictator", someVersionMocked.Object, dependenciesMocked.Object);

            //Returns -1 if otherVersion version is Higher
            Assert.AreEqual(-1, 
                package.CompareTo(coolerPackageMocked.Object));
        }

        [Test]
        public void CompareTo_ShouldReturnExpectedResult_WhenOtherPackageIsWithLowerVersion()
        {
            var someVersionMocked = new Mock<IVersion>();
            var dependenciesMocked = new Mock<ICollection<IPackage>>();
            var coolerPackageMocked = new Mock<IPackage>();
            var higherVersion = new Mock<IVersion>();
            someVersionMocked.Setup(
                m => m.Major).Returns(10);

            coolerPackageMocked.Setup(
                m => m.Name).Returns("The_Dictator");

            coolerPackageMocked.Setup(
                m => m.Version).Returns(higherVersion.Object);

            var package = new Package(
                "The_Dictator", someVersionMocked.Object, dependenciesMocked.Object);

            //Returns 1 if otherVersion version is Lower
            Assert.AreEqual(1,
                package.CompareTo(coolerPackageMocked.Object));
        }

        [Test]
        public void CompareTo_ShouldReturnExpectedResult_WhenOtherPackageIsWithTheSameVersion()
        {
            var someVersionMocked = new Mock<IVersion>();
            var dependenciesMocked = new Mock<ICollection<IPackage>>();
            var coolerPackageMocked = new Mock<IPackage>();
            var higherVersion = new Mock<IVersion>();

            coolerPackageMocked.Setup(
                m => m.Name).Returns("The_Dictator");

            coolerPackageMocked.Setup(
                m => m.Version).Returns(higherVersion.Object);

            var package = new Package(
                "The_Dictator", someVersionMocked.Object, dependenciesMocked.Object);

            //Returns 0 if both packages have same version
            Assert.AreEqual(0,
                package.CompareTo(coolerPackageMocked.Object));
        }
    }
}
