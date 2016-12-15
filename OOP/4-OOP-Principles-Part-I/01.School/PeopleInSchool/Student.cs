
namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a student.
    /// </summary>
    public class Student : Person,ICommentable
    {
        private List<string> comments = new List<string>();
        /// <summary>
        /// Initializes new instance of student class to the specified name and class number.
        /// </summary>
        /// <param name="name">Name of the student.</param>
        /// <param name="classNumber">Student's class number.</param>
        public Student(string name, int classNumber)
            : base(name)
        {
            this.ClassNumber = classNumber;
        }

        /// <summary>
        /// Gets class number of the student.
        /// </summary>
        public int ClassNumber { get; private set; }

        public List<string> Comments { get; }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }
    }
}