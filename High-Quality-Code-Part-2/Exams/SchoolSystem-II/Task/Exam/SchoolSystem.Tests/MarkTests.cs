namespace SchoolSystem.Tests
{
    using CLI.Models;
    using CLI.Models.Enums;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class MarkTests
    {
        [Test]
        public void Constructor_MustInitializeCorretly_SubjectAndValue()
        {
            var mark = new Mark(Subject.Bulgarian, 5);
            Assert.AreEqual(mark.Subject, Subject.Bulgarian);
            Assert.AreEqual(mark.Value, 5);
        }

        [TestCase(Subject.Bulgarian)]
        [TestCase(Subject.English)]
        [TestCase(Subject.Math)]
        [TestCase(Subject.Programming)]
        public void Subject_ShouldBe_Initilialized_Correctly(Subject subject)
        {
            var mark = new Mark(subject, 5);
            Assert.AreEqual(mark.Subject, subject);
        }

        [TestCase(2)]
        [TestCase(2.5f)]
        [TestCase(6)]
        [TestCase(5.9f)]
        public void Value_ShouldBe_Initilialized_Correctly(float value)
        {
            var mark = new Mark(Subject.Bulgarian, value);
            Assert.AreEqual(mark.Value, value);
        }

        [TestCase(1.9f)]
        [TestCase(1)]
        [TestCase(6.1f)]
        [TestCase(7)]
        [TestCase(-1)]
        [TestCase(-1.4f)]
        public void Value_ShouldThrow_ArgumentException_WhenNotCorrect(float value)
        {
           Assert.Throws<ArgumentException>(()=> new Mark(Subject.Bulgarian, value));          
        }
    }
}
