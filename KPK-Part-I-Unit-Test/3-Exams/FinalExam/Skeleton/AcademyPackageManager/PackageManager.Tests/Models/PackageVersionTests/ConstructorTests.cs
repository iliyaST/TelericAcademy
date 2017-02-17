using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.ModelsPackageVersion
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        [TestCase(10)]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(2)]
        public void Constructor_ShouldSetTheAppropriate_PassedValues_Major(int major)
        {
            var packageVersion = new PackageVersion(major, 5, 2, VersionType.beta);

            Assert.AreEqual(major, packageVersion.Major);
        }

        [Test]
        [TestCase(10)]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(2)]
        public void Constructor_ShouldSetTheAppropriate_PassedValues_Minor(int minor)
        {
            var packageVersion = new PackageVersion(10, minor, 2, VersionType.beta);

            Assert.AreEqual(minor, packageVersion.Minor);
        }

        [Test]
        [TestCase(10)]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(2)]
        public void Constructor_ShouldSetTheAppropriate_PassedValues_Patch(int patch)
        {
            var packageVersion = new PackageVersion(10, 5, patch, VersionType.beta);

            Assert.AreEqual(patch, packageVersion.Patch);
        }

        [Test]
        [TestCase(VersionType.alpha)]
        [TestCase(VersionType.beta)]
        [TestCase(VersionType.final)]
        [TestCase(VersionType.rc)]
        public void Constructor_ShouldSetTheAppropriate_PassedValues_VersionType(VersionType vt)
        {
            var packageVersion = new PackageVersion(10, 5, 2, vt);

            Assert.AreEqual(vt, packageVersion.VersionType);
        }
    }
}
