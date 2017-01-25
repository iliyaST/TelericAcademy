using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;
using System.Collections.Generic;

namespace School.Test
{
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckIfStudentsNameIsEmptyShouldThrowArgumentExeption()
        {
            //Assign
            var student = new Student()
            {
                Name = ""           
            };                    
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckIfStudentsNameIsNullShouldThrowArgumentExeption()
        {
            //Assign
            var student = new Student()
            {
                Name = null,
                Id = "12312441"
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        
        public void IdMustBeMore10000ShouldThrowExeptionOtherwise()
        {
            var student = new Student()
            {
                Id = "1"
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]

        public void IdMustBeLessThan99999ShouldThrowExeptionOtherwise()
        {
            var student = new Student()
            {
                Id = "1241944128"
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        public void CourseMustCointain30orLessThan30Students()
        {
            //Asign
            var course = new Course();
            course.Students = new List<Student>();

            //Act and Assert
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
            course.Add(new Student("10001"));
        }
    }
}
