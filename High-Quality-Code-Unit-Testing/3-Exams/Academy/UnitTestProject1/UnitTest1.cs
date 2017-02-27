using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Moq;
using NUnit.Framework;
using System;

namespace UnitTestProject1
{
   [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var season = new Season(2016, 2017, Initiative.CoderDojo);
            var studentMocked = new Mock<IStudent>();
            var trainerMocked = new Mock<ITrainer>();

            studentMocked.Setup(
                m => m.ToString()).Returns("student");
            trainerMocked.Setup(
                m => m.ToString()).Returns("trainer");

            season.Students.Add(studentMocked.Object);
            season.Trainers.Add(trainerMocked.Object);

            season.ListUsers();

            trainerMocked.Verify(
                m => m.ToString(),Times.Once);

            studentMocked.Verify(
                m => m.ToString(), Times.Once);
        }
    }
}
