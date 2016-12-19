
namespace StudentClass
{
    using System;
    using System.Collections.Generic;

    public class Test
    {
        public static void Main()
        {
            //make some students
            Student student1 = new Student("Iliya", "Martin", "St", "1223", "asd", "123312312", "ss", 2, Specialty.AppliedMathematics, University.NewBulgarianUniversity, Faculty.Electronics);
            Student student2 = new Student("Jenn", "S", "Nest", "7223", "aaasd", "123312312", "ss", 4, Specialty.AppliedMathematics, University.NewBulgarianUniversity, Faculty.Electronics);
            Student student3 = new Student("Boris", "Martin", "St", "9423", "asd", "123312312", "ss", 2, Specialty.AppliedMathematics, University.NewBulgarianUniversity, Faculty.Electronics);
            Student student4 = new Student("John", "Martin", "St", "2023", "asd", "123312312", "ss", 2, Specialty.AppliedMathematics, University.SofiaUniversity, Faculty.Informatics);

            //some cloning
            Student student5 = (Student)student1.Clone();

            //check if our ovveride operator works
            Console.WriteLine(student1 == student2);
            Console.WriteLine(student1 == student3);
            Console.WriteLine(student1 + student2);
            Console.WriteLine(student5.ToString());

            //test CompareTo method
            if (student4.CompareTo(student1) > 0)
            {
                Console.WriteLine("{0} {1} > {2} {3} ", student4.FirstName, student4.SSN
                    , student1.FirstName, student1.SSN);
            }
            else
            {
                Console.WriteLine("{0} {1} < {2} {3} ", student4.FirstName, student4.SSN
                   , student1.FirstName, student1.SSN);
            }

            //You can try it with normal list...i dont feel the need to do it.
            var sortedSet = new SortedSet<Student>();

            sortedSet.Add(student1);
            sortedSet.Add(student2);
            sortedSet.Add(student3);
            sortedSet.Add(student4);
            sortedSet.Add(student5);

            foreach (var student in sortedSet)
            {
                Console.WriteLine(student.FirstName + " " + student.SSN);
            }
        }
    }
}