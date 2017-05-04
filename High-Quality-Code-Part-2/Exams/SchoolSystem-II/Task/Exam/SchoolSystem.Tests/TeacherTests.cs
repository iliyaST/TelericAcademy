using Moq;
using NUnit.Framework;
using SchoolSystem.CLI.Models;
using SchoolSystem.CLI.Models.Contracts;
using SchoolSystem.CLI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Tests
{
    [TestFixture]
    public class TeacherTests
    {
        [Test]
        public void Constructor_ShouldAssignCorrectValuesToProperties()
        {
            var teacher = new Teacher("Lambriana", "Yanakieva", Subject.Programming);
            Assert.AreEqual("Lambriana", teacher.FirstName);
            Assert.AreEqual("Yanakieva", teacher.LastName);
            Assert.AreEqual(Subject.Programming, teacher.Subject);
        }

        [Test]
        public void Property_FirstName_ShouldBeCorrectlyAssign()
        {
            var teacher = new Teacher("Lambriana", "Yanakieva", Subject.Programming);
            Assert.AreEqual("Lambriana", teacher.FirstName);
        }

        [Test]
        public void Property_LastName_ShouldBeCorrectlyAssign()
        {

            var teacher = new Teacher("Lambriana", "Yanakieva", Subject.Programming);

            Assert.AreEqual("Yanakieva", teacher.LastName);

        }

        [Test]
        public void Property_Subject_ShouldBeCorrectlyAssign()
        {
            var teacher = new Teacher("Lambriana", "Yanakieva", Subject.Programming);

            Assert.AreEqual(Subject.Programming, teacher.Subject);

        }
        
        [Test]
        public void AddMarks_ShouldWorkCorrectly()
        {
            var studentMocked = new Mock<IStudent>();
            var teacher = new Teacher("Lambriana", "Yanakieva", Subject.Programming);
            var mark = new Mock<IMark>();
            var mark1 = new Mock<IMark>();

            studentMocked.Setup(m => m.Marks).Returns(new List<IMark>());

            teacher.AddMark(studentMocked.Object, mark.Object);
            teacher.AddMark(studentMocked.Object, mark1.Object);

            Assert.AreEqual(studentMocked.Object.Marks.Count, 2);
        }
    }
}
