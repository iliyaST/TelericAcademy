using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.ProjectTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void PackageRepository_MustBeSetCorrectly_ForOptionalParameterPackages()
        {
            var project = new Project("Spider-Man's project",
                "SomeWhereeee over the rainbow!!!!");

            Assert.IsNotNull(project.PackageRepository);
        }

        [Test]
        public void PackageRepository_MustBeSetCorrectly_ForPassedParameterPackages()
        {
            var packagesMocked = new Mock<IRepository<IPackage>>();
            var project = new Project("Spider-Man's project",
                "SomeWhereeee over the rainbow!!!!",packagesMocked.Object);

            Assert.AreEqual(packagesMocked.Object, project.PackageRepository);
        }
    }
}
