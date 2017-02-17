using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.PackageVersionTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [Test]
        public void Major_ShouldThrowArgumentExepction_IfInvalidValue_WassPassed()
        {
            Assert.Throws<ArgumentException>(
                () => new PackageVersion(-1, 5, 2, VersionType.beta));
        }

        [Test]
        public void Major_ShouldCorrectlySetMajor_IfValidValueWasPassed()
        {
            var packageVersion = new PackageVersion(5, 5, 2, VersionType.beta);

            Assert.AreEqual(5, packageVersion.Major);
        }

        [Test]
        public void Minor_ShouldThrowArgumentExepction_IfInvalidValue_WassPassed()
        {
            Assert.Throws<ArgumentException>(
                () => new PackageVersion(5, -1, 2, VersionType.beta));
        }

        [Test]
        public void Minor_ShouldCorrectlySetMajor_IfValidValueWasPassed()
        {
            var packageVersion = new PackageVersion(5, 5, 2, VersionType.beta);

            Assert.AreEqual(5, packageVersion.Minor);
        }

        [Test]
        public void Patch_ShouldThrowArgumentExepction_IfInvalidValue_WassPassed()
        {
            Assert.Throws<ArgumentException>(
                () => new PackageVersion(5, 5, -1, VersionType.beta));
        }

        [Test]
        public void Patch_ShouldCorrectlySetMajor_IfValidValueWasPassed()
        {
            var packageVersion = new PackageVersion(5, 5, 2, VersionType.beta);

            Assert.AreEqual(2, packageVersion.Patch);
        }

        [Test]
        public void VersionType_ShouldThrowArgumentExepction_IfInvalidValue_WassPassed()
        {
            Assert.Throws<ArgumentException>(
               () => new PackageVersion(5, 5, 2, 
               (VersionType)(124)));
        }

        [Test]
        public void VersionType_ShouldCorrectlySetMajor_IfValidValueWasPassed()
        {
            var packageVersion = new PackageVersion(5, 5, 2, VersionType.beta);

            Assert.AreEqual(VersionType.beta, packageVersion.VersionType);
        }
    }
}
