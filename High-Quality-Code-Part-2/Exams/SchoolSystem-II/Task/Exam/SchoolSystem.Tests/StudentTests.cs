namespace SchoolSystem.Tests
{
    using CLI.Models;
    using CLI.Models.Contracts;
    using CLI.Models.Enums;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class StudentTests
    {
        [Test]
        public void Constructor_ShouldAssignCorrectValue_ToParameters()
        {
            var students = new Student("Lambriana", "Yanakieva", Grade.Sixth);
            Assert.AreEqual("Lambriana", students.FirstName);
            Assert.AreEqual("Yanakieva", students.LastName);
            Assert.AreEqual(Grade.Sixth, students.Grade);

        }

        [Test]
        public void Constructor_ShouldCorrectlyAssignMarks()
        {
            var student = new Student("Lambriana", "Yanakieva", Grade.Sixth);
            Assert.AreEqual(student.Marks, new List<IMark>());
        }

        [Test]
        public void Property_FirstName_ShouldBeCorrectlyAssign()
        {

            var students = new Student("Lambriana", "Yanakieva", Grade.Sixth);
            Assert.AreEqual("Lambriana", students.FirstName);

        }

        [Test]
        public void Property_LastName_ShouldBeCorrectlyAssign()
        {

            var students = new Student("Lambriana", "Yanakieva", Grade.Sixth);
            Assert.AreEqual("Yanakieva", students.LastName);

        }

        [Test]
        public void Property_Grade_ShouldBeCorrectlyAssign()
        {

            var students = new Student("Lambriana", "Yanakieva", Grade.Sixth);
            Assert.AreEqual(Grade.Sixth, students.Grade);

        }
        [Test]
        public void Property_Marks_ShouldBeCorrectlyAssign()
        {
            var mark = new Mock<IMark>();
            var student = new Student("Pesho", "Kalibara", Grade.Eighth);

            student.Marks.Add(mark.Object);

            Assert.AreEqual(student.Marks.Count, 1);
        }

        [Test]
        public void ListMarks_ShouldListAllStudentMarks()
        {
            var markMocked = new Mock<IMark>();
            var student = new Student("az", "sum", Grade.First);

            student.Marks.Add(markMocked.Object);

            student.ListMarks();

            markMocked.Verify(mark => mark.Value, Times.Exactly(1));
            markMocked.Verify(mark => mark.Subject, Times.Exactly(1));
        }

        [Test]
        public void ListMarks_ShouldReturnCorrectMessage_WhenNoMarksArePassed()
        {
            const string StudentHasNoMarks = "This student has no marks.";

            var student = new Student("az", "sum", Grade.First);



            var act = student.ListMarks();

            StringAssert.Contains(StudentHasNoMarks, act);

        }
    }
}



