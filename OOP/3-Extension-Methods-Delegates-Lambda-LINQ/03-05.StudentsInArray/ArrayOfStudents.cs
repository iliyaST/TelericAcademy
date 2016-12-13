using System;
using System.Linq;

namespace StudentsInArray
{
    class ArrayOfStudents
    {
        static void Main()
        {
            //Array of students
            var students = new[]
            {
                new { FirstName = "Gandalf", LastName = "The Grey", age = 18},
                new { FirstName = "Gandalf", LastName = "The White", age = 24},
                new { FirstName = "Spider Man", LastName = "The Red", age = 56},
                new { FirstName = "Spider Man", LastName = "The Black", age = 21},
                new { FirstName = "Iron Man", LastName = "The Red", age = 16},
            };

            //Select students 
            var selectedStudentsByFirstAndLastName =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            //print them
            foreach (var student in selectedStudentsByFirstAndLastName)
            {
                Console.WriteLine(student.LastName + " " + student.FirstName);
            }

            //select by age
            var selectedStudentByAge =
                from student in students
                where student.age >= 18 && student.age <= 24
                orderby student.age
                select student;

            foreach (var student in selectedStudentByAge)
            {
                Console.WriteLine(student);
            }

            //Order by and than by (sort the array using lampda)
            var sortedArrayOfStudents =
                students.OrderByDescending(x => x.FirstName)
                .ThenByDescending(x => x.LastName);

            //Order by and than by using LINQ
            var sortedArrayOfStudentsLINQ =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;       
        }
    }
}
