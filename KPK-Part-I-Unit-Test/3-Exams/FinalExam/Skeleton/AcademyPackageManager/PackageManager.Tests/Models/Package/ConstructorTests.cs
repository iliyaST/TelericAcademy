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
    public class ConstructorTests
    {
        [Test]
        public void Dependencies_ShouldBeSetCorrectly_ForOptionalParameter_Dependencies()
        {
            var someVersion = new Mock<IVersion>();

            var package = new Package(
                "NekvoImeChoek", someVersion.Object);

            Assert.IsNotNull(package.Dependencies);
        }

        [Test]
        public void Dependencies_ShouldBeSetCorrectly_ForPassedParameter_Dependencies()
        {
            var someVersion = new Mock<IVersion>();
            var dependencies = new Mock<ICollection<IPackage>>();

            someVersion.Setup(
                m => m.Major).Returns(10);

            someVersion.Setup(
                m => m.Minor).Returns(5);

            someVersion.Setup(
                m => m.Patch).Returns(2);

            someVersion.Setup(
                m => m.VersionType).Returns(VersionType.beta);

            var package = new Package(
                "NekvoImeChoek", someVersion.Object,dependencies.Object);

            var expected = string.Format("{0}.{1}.{2}-{3}",
                10, 5, 2, VersionType.beta);

            Assert.AreEqual(expected, package.Url);
        }
    }
}
