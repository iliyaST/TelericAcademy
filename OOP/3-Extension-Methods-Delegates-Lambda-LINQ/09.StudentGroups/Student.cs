using System;
using System.Collections.Generic;

namespace StudentGroups
{
    /// <summary>
    /// Student Object
    /// </summary>
    public class Student
    {
        //FirstName, LastName, FN, Tel, Email, Marks (a List), GroupNumber.
        public string FN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<int> Marks { get; set; }
        public string Tel { get; set; }
        public int GroupNumber { get; set; }


        public Student(string firstName, string lastName, string fn, string tel,
            string email, int groupNumber, List<int> marks, int group)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FN = fn;
            this.Tel = tel;
            this.Email = email;
            this.GroupNumber = group;
            this.Marks = marks;

        }

        public override string ToString()
        {
            return String.Format("First Name: {0}\nLast Name: {1}\nFn: {2}\nTel: {3}\nE-mail: {4}\n"+
                "Group Number:{5}\n", this.FirstName, this.LastName, this.FN, this.Tel, this.Email, this.GroupNumber);
        }

    }
}
