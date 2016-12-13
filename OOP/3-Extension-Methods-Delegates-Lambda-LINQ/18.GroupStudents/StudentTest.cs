
namespace GroupStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class StudentTest
    {
        static void Main()
        {

            //"132503", "064696011", "dwayne@abv.bg", 1, new List<int>() { 2,2,1 }, 1),
            var listOfStudents = new []
            {
                new { FirstName = "Arnold", LastName = "Belia",Group=3 },
                new { FirstName = "Bruce", LastName = "Lee",Group=2 },
                new { FirstName = "Goshkata", LastName = "Peshov",Group=1 },
                new { FirstName = "Peshkata", LastName = "Goshov",Group=2 },
                new { FirstName = "Ivan", LastName = "Boikov",Group=3 }
            };

            Console.WriteLine();
            Console.WriteLine("USING LINQ");
            Console.WriteLine(new string('-', 60));

            //group by GroupNumber using LINQ
            var selectStudentsLINQ =
                from student in listOfStudents
                group student by student.Group into g
                select g;

            foreach (var group in selectStudentsLINQ)
            {
                Console.WriteLine(group.Key);

                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }
            }

            Console.WriteLine();
            Console.WriteLine("USING EXTENSION METHODS");
            Console.WriteLine(new string('-',60));

            //group by groupNumber using extension methods
            var selectStudents =
                listOfStudents
                .GroupBy(st => st.Group)
                .ToList();

            foreach (var group in selectStudents)
            {
                Console.WriteLine(group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }
            }
        }
    }
}