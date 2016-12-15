
namespace Humans
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Test
    {
        public static void Main()
        {
            //Initialize a list of 10 students and sort them by grade in ascending order 
            //(use LINQ or OrderBy() extension method).
            //Initialize a list of 10 workers and sort them by money per hour in descending order.
            //Merge the lists and sort them by first name and last name.

            List<Student> listOfStudents = new List<Student>
            {
                new Student("Stefcho","Pichagata",2),
                new Student("Bat","Boiko",6),
                new Student("Rosen4o","Plevneliev",4),
                new Student("Arnold","MuscleMan",3),
                new Student("Pesho","Picha",5),
                new Student("Gosho","Lamiata",2),
                new Student("StiaBe","Comeone",5),
                new Student("Iliya","Stamvolov",6),
                new Student("Jenny","Nestorova",6),
                new Student("Ann","Kostadinova",4),
            };

            var sortedStudents = listOfStudents.OrderBy(st => st.Grade);

            foreach (var student in sortedStudents)
            {
                Console.WriteLine("FirstName: " + student.FirstName + " Grade: " + student.Grade);
            }

            //WORKERERRRRRRRRRRSSSSSSSSSSSS
            Console.WriteLine();
            Console.WriteLine("WORKER SECTION_________________________________");
            Console.WriteLine();

            List<Worker> listOfWorkers = new List<Worker>
            {
                new Worker("Stefcho","Pichagata",100,5),
                new Worker("Bat","Boiko",1004,5),
                new Worker("Rosen4o","Plevneliev",500,6),
                new Worker("Arnold","MuscleMan",2002,10),
                new Worker("Pesho","Picha",5,1),
                new Worker("Gosho","Lamiata",6,2),
                new Worker("StiaBe","Comeone",44,9),
                new Worker("Iliya","Stamvolov",240,8),
                new Worker("Jenny","Nestorova",100,6),
                new Worker("Ann","Kostadinova",400,1),
            };

            var sortedWorkers = listOfWorkers.OrderByDescending(wr => wr.MoneyPerHour());

            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine("FirstName: " + worker.FirstName + " LastName: " + worker.LastName + " MoneyPerHour: " + worker.MoneyPerHour());
            }

            Console.WriteLine();
            Console.WriteLine("Merged List");
            Console.WriteLine();

            // Merge lists into human list and order by first name then by last name.
            IEnumerable<Human> humans = new List<Human>()
                .Concat(listOfStudents)
                .Concat(listOfWorkers)
                .OrderBy(human => human.FirstName)
                .ThenBy(human => human.LastName);

            // Print merged list
            Console.WriteLine(new string('-', 25));
            foreach (var human in humans)
            {
                Console.WriteLine("{0} {1}", human.FirstName, human.LastName);
            }
        }
    }
}
