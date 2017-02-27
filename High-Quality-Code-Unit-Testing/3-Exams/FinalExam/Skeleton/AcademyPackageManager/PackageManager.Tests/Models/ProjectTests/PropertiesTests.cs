using NUnit.Framework;
using PackageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.ProjectTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [Test]
        public void Name_MustBeSet_Correctly_IfPassedValue_IsValid()
        {
            var project = new Project("Spider-Man's project",
               "SomeWhereeee over the rainbow!!!!");

            Assert.AreEqual("Spider-Man's project",
                project.Name);

        }

        [Test]
        public void Location_MustBeSet_Correctly_IfPassedValue_IsValid()
        {
            var project = new Project("Batman Revnuva i Zavijda's project",
               "SomeWhereeee over the rainbow!!!!");

            Assert.AreEqual("SomeWhereeee over the rainbow!!!!",
                project.Location);
        }
    }
}
