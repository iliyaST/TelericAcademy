
namespace StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentTest
    {

        public static void Main()
        {
            List<Student> listOfStudents = new List<Student>
            {
                new Student("Dwayne", "Johnson", "132503", "064696011", "dwayne@abv.bg", new List<int>() { 2,2,1 }, 1),
                new Student("Vin", "Diesel", "122606", "0873669952", "diesel@gmail.com", new List<int>() { 3, 5, 3, 4 }, 2),
                new Student("Rosie", "Huntington-Whiteley", "206006", "026505543", "rose@abv.bg", new List<int>() { 2, 6}, 3),
                new Student("Jason", "Statham","504503", "027304441", "jason@hotmail.com", new List<int>() { 3, 5 }, 3),
                new Student("Megan", "Fox", "607506", "020256973", "m.fox@abv.bg", new List<int>() { 2, 4, 2 }, 2),
                new Student("Miranda", "Kerr","025011", "0888123321", "kerr@abv.bg", new List<int>() { 6, 5, 5, 4 }, 1),
                new Student("Leonardo", "DiCaprio", "054206", "064885203", "di@gmail.com", new List<int>() { 6 }, 2),
                new Student("Emma", "Watson", "321012", "021234567", "emma@abv.bg", new List<int>() { 6, 6, 6, 6, 6 }, 3),
                new Student("Kristen ", "Stewart", "124206", "0897030405", "stewart.kristen@abv.bg", new List<int>() { 5 }, 2),
                new Student("Selena ", "Gomez", "508205", "026547891", "sgomez@gmail.com", new List<int>() { 6, 5 }, 1),
                new Student("Miley", "Cyrus", "087006", "021346795", "miley@abv.bg", new List<int>() { 6 }, 2),
                new Student("Taylor", "Swift", "325510", "029764315", "swift@abv.bg", new List<int>() { 2, 2,3,4 }, 3),
            };

            //First task: Select students with group "2" using LINQ query and print
            //SelectedByGroupNumberLINQ(listOfStudents);                               (uncomment!!)

            //Second task: Order studetns by first name using LINQ query
            //OrderByFirstNameLINQ(listOfStudents);                                    (uncomment!)

            //Third task: Use Extension Methods
            //SelectStudentsByGroupAndOrderByFirstNameUsingExtensions(listOfStudents); (uncomment!)

            //Fourth Task: Select students with abv.bg
            //SelectByEmail(listOfStudents);                                           (uncomment!)

            //Fifth Task: Extract all students with phones in Sofia (must starts with 02)
            //SelectByPhoneInSofia(listOfStudents);                                    (uncomment!)

            //Sixth Task: Extract student by marks
            //SelectByMark(listOfStudents);                                            (uncomment!) 

            //Seventh Task: Extract students with two "2" marks
            //ExtractByMark(listOfStudents);                                           (uncomment!)

            //Extract all Marks of the students that enrolled in 2006. 
            //(The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
            //ExtractByFN(listOfStudents);                                             (uncomment!)

            //Group
            //Group(listOfStudents);
        }

        public static void Group(List<Student> listOfStudents)
        {
            Group[] groups = new Group[]
          {
                new Group(1, "Science"),
                new Group(2, "Mathematics"),
                new Group(3, "Physics")
          };

            // Extract all students from mathematics department
            var mathGroup =
                from student in listOfStudents
                join gr in groups on student.GroupNumber equals gr.GroupNumber
                where gr.DepartmentName == "Mathematics"
                select new
                {
                    FullName = string.Format("{0} {1}", student.FirstName, student.LastName),
                    Department = gr.DepartmentName
                };

            // Print students from mathematics department
            Console.WriteLine("16.Students from mathematics department.");

            foreach (var student in mathGroup)
            {
                Console.WriteLine("{0} - {1}", student.FullName, student.Department);
            }
        }

        public static void ExtractByFN(List<Student> listOfStudents)
        {
            var selectStudents =
                listOfStudents
                .Where(st => st.FN.ToString()[4] == '0' && st.FN.ToString()[5] == '6')
                .Select(st => st);

            foreach (var student in selectStudents)
            {
                Console.WriteLine(student.FirstName+" "+student.FN);
            }
        }

        public static void ExtractByMark(List<Student> listOfStudents)
        {
            var exelentStudentsList =
                listOfStudents
                .Where(student => student.Marks
                    .Where(mark => mark == 2)
                    .Count() == 2)
                 .Select(student => new
                 {
                     FullName = String.Format("First name: {0} Last name: {1}", student.FirstName, student.LastName),
                     Marks = student.Marks
                 });
                

            // Print result
            foreach (var student in exelentStudentsList)
            {
                // Join mark into string
                Console.WriteLine("{0} Marks: {1}", student.FullName, string.Join(", ", student.Marks));
            }
        }

        public static void SelectByMark(List<Student> listOfStudents)
        {
            var exelentStudents =
               from student in listOfStudents
               where student.Marks.Contains(6)
               select new
               {
                   FullName = string.Format("{0} {1}", student.FirstName, student.LastName),
                   Marks = student.Marks
               };

            // Print exelect students
            Console.WriteLine("13.Exelent students: ");
            foreach (var student in exelentStudents)
            {
                // Join mark into string
                Console.WriteLine("{0} Marks: {1}", student.FullName, string.Join(", ", student.Marks));
            }
        }

        public static void SelectByPhoneInSofia(List<Student> listOfStudents)
        {
            var selectStudents =
                from student in listOfStudents
                where student.Tel.StartsWith("02")
                select student;

            foreach (var student in selectStudents)
            {
                Console.WriteLine(student.FirstName + " " + student.Tel);
            }
        }

        public static void SelectByEmail(List<Student> listOfStudents)
        {
            var selectStudentsByEmail =
               from student in listOfStudents
               where student.Email.Contains("abv.bg")
               select student;

            Console.WriteLine("Print Students with main abv.bg");
            foreach (var student in selectStudentsByEmail)
            {
                Console.WriteLine(student.Email);
            }
        }

        public static void SelectStudentsByGroupAndOrderByFirstNameUsingExtensions(List<Student> listOfStudents)
        {
            var orderedStudentsOther = listOfStudents
               .FindAll(st => st.GroupNumber == 2)
               .OrderBy(st => st.FirstName);

            Console.WriteLine("ORDEREDD#######################");
            foreach (var student in orderedStudentsOther)
            {
                Console.WriteLine(student.ToString());
            }
        }

        public static void OrderByFirstNameLINQ(List<Student> listOfStudents)
        {
            var orderedStudents =
               from student in listOfStudents
               orderby student.FirstName descending
               select student;

            Console.WriteLine("Sorted List by First Name");
            Console.WriteLine(new string('-', 20));
            foreach (var student in orderedStudents)
            {
                Console.WriteLine(student.ToString());
            }
        }

        public static void SelectedByGroupNumberLINQ(List<Student> listOfStudents)
        {
            var selectedStudentsWithSpecifiedGroup =
                from student in listOfStudents
                where student.GroupNumber == 2
                select student;

            Console.WriteLine("Selected students with group 2");
            Console.WriteLine(new string('-', 20));
            //print
            foreach (var student in selectedStudentsWithSpecifiedGroup)
            {
                Console.WriteLine(student);
            }
        }
    }
}
