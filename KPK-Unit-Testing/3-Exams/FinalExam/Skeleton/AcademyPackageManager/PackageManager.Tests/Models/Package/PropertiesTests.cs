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
    public class PropertiesTests
    {
        [Test]
        public void Name_MustBeSetCorrectly_WhenValidValueIsPassed()
        {
            var someVersion = new Mock<IVersion>();
            var dependencies = new Mock<ICollection<IPackage>>();

            var package = new Package(
                "NekvoImeChoek", someVersion.Object, dependencies.Object);

            Assert.AreEqual("NekvoImeChoek", package.Name);
        }

        [Test]
        public void Version_MustBeSetCorrectly_WhenValidValueIsPassed()
        {
            var someVersion = new Mock<IVersion>();
            var dependencies = new Mock<ICollection<IPackage>>();

            var package = new Package(
                "NekvoImeChoek", someVersion.Object, dependencies.Object);

            Assert.AreEqual(someVersion.Object, package.Version);
        }

        [Test]
        public void Url_MustBeSetCorrectly_WhenValidValueIsPassed()
        {
            var someVersion = new Mock<IVersion>();
            var dependencies = new Mock<ICollection<IPackage>>();

            var package = new Package(
                "NekvoImeChoek", someVersion.Object, dependencies.Object);

            Assert.AreEqual("NekvoImeChoek", package.Name);
        }
    }
}
