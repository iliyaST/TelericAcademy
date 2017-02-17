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
    public class GetAllTests
    {
        [Test]
        public void GetAll_ShouldReturnEmptyCollection_IfThereAreNoPackages()
        {
            var loggerMocked = new Mock<ILogger>();
            var packageMocked = new Mock<IPackage>();
            var packages = new List<IPackage>() {  };

            var repository = new PackageRepository(loggerMocked.Object,
               packages);

            Assert.IsEmpty(repository.GetAll());
        }

        [Test]
        public void GetAll_EqualNumberOfElements()
        {
            var loggerMocked = new Mock<ILogger>();
            var packageMocked = new Mock<IPackage>();
            var packages = new List<IPackage>() { packageMocked.Object,
            packageMocked.Object};

            var repository = new PackageRepository(loggerMocked.Object,
               packages);

            var collection = repository.GetAll();

            Assert.AreEqual(2,collection.Count());
        }
    }
}
