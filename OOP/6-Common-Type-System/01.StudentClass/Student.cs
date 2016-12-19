
namespace StudentClass
{
    using System;
    using System.Text;

    //    Define a class Student, which contains data about a student – first, middle and last name,
    //        SSN, permanent address, mobile phone e-mail, course, specialty, university,
    //        faculty.Use an enumeration for the specialties, universities and faculties.
    //Override the standard methods, inherited by System.Object: Equals(), ToString(),
    //    GetHashCode() and operators == and !=.

    /// <summary>
    /// Initialize a student
    /// </summary>
    public class Student : ICloneable, IComparable
    {
        /// <summary>
        /// Initialize empty constructor
        /// </summary>
        public Student()
        {

        }
        /// <summary>
        /// Create istance of Student
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="thirdName"></param>
        public Student(string firstName, string secondName, string thirdName, string ssn, string permanentAdress
            , string mobilePhone, string email, int course,
            Specialty specalty, University university, Faculty faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = secondName;
            this.LastName = thirdName;
            this.SSN = ssn;
            this.PermanentAdress = permanentAdress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.Specalty = specalty;
            this.University = university;
            this.Faculty = faculty;
        }
        /// <summary>
        /// Properties
        /// </summary>
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string PermanentAdress { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public int Course { get; set; }
        public Specialty Specalty { get; set; }
        public University University { get; set; }
        public Faculty Faculty { get; set; }

        //Overide some operators :)
        public static bool operator ==(Student first, Student second)
        {
            // Returns true if two students are equal
            return first.Equals(second);
        }

        public static bool operator !=(Student first, Student second)
        {
            // Returns the opposite of the equals operator
            return !(first == second);
        }

        public static int operator +(Student st1, Student st2)
        {
            return st1.Course + st2.Course;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current student.
        /// </summary>
        /// <param name="obj">The object to compare to the current student.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            // Check if object is null
            if (obj == null)
            {
                return false;
            }

            // Cast object to student
            Student student = obj as Student;

            // Check if object is not Student derived 
            if (student == null)
            {
                return false;
            }

            // Return true if students are equal. University and SSN uniquely identifies a student.
            if (this.FirstName != student.FirstName)
            {
                return false;
            }
            if (this.MiddleName != student.MiddleName)
            {
                return false;
            }
            if (this.LastName != student.LastName)
            {
                return false;
            }
            if (this.Faculty != student.Faculty)
            {
                return false;
            }
            //and so on.... you get the picture....

            //return true if all are true
            return true;
        }

        /// <summary>
        /// Return a hashcode of the current student.
        /// </summary>
        public override int GetHashCode()
        {
            return this.University.GetHashCode() ^ this.SSN.GetHashCode();
        }

        /// <summary>
        /// overide CompareTo method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            Student someObj = (Student)obj;
            if (this.FirstName.CompareTo(someObj.FirstName) < 0)
            {
                if (this.SSN.CompareTo(someObj.SSN) < 0)
                {
                    return -1;
                }
                if (this.SSN.CompareTo(someObj.SSN) > 0)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else if (this.SSN.CompareTo(someObj.SSN) > 0)
            {
                if (this.SSN.CompareTo(someObj.SSN) < 0)
                {
                    return -1;
                }
                else if (this.SSN.CompareTo(someObj.SSN) > 0)
                {
                    return 1;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                if (this.SSN.CompareTo(someObj.SSN) < 0)
                {
                    return -1;
                }
                else if (this.SSN.CompareTo(someObj.SSN) > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        //override Clone method
        public object Clone()
        {
            Student obj = new Student();

            obj.Course = this.Course;
            obj.Email = this.Email;
            obj.Faculty = this.Faculty;
            obj.FirstName = this.FirstName;
            obj.MiddleName = this.MiddleName;
            obj.LastName = this.LastName;
            obj.PermanentAdress = this.PermanentAdress;
            obj.SSN = this.SSN;
            obj.University = this.University;
            obj.Specalty = this.Specalty;

            return obj;
        }

        /// <summary>
        /// Returns a string that represents the current student.
        /// </summary>
        /// <returns>Student string representation.</returns>
        public override string ToString()
        {
            StringBuilder studentInfo = new StringBuilder();

            // Append student info
            studentInfo.AppendLine(string.Format("Name - {0} {1} {2}", this.FirstName, this.MiddleName, this.LastName));
            studentInfo.AppendLine(string.Format("Student number - {0}", this.SSN));
            studentInfo.AppendLine(string.Format("Address - {0}", this.PermanentAdress));
            studentInfo.AppendLine(string.Format("Phone - {0}", this.MobilePhone));
            studentInfo.AppendLine(string.Format("Course - {0}", this.Course));
            studentInfo.AppendLine(string.Format("Specialty - {0}", this.Specalty));
            studentInfo.AppendLine(string.Format("University - {0}", this.University));
            studentInfo.AppendLine(string.Format("Faculty - {0}", this.Faculty));

            // Return student info as a string
            return studentInfo.ToString();
        }
    }
}
