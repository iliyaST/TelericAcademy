

namespace School
{
    using System.Collections.Generic;

    public class ClassOfStudents : ICommentable
    {
        private string uniqueTextIdentifier;
        private List<Student> setOfStudents = new List<Student>();
        private List<Teacher> setOfTeachers = new List<Teacher>();
        private List<string> comments = new List<string>();

        public ClassOfStudents(string name)
        {
            this.uniqueTextIdentifier = name;
        }

        public ClassOfStudents(string name, string comment)
        {
            this.uniqueTextIdentifier = name;
            this.comments.Add(comment);
        }

        //add student
        public void AddStudent(Student student)
        {
            this.setOfStudents.Add(student);
        }

        //remove student
        public void RemoveDiscipline(Student student)
        {
            this.setOfStudents.Remove(student);
        }

        //get all student as a list
        public List<Student> GetStudents()
        {
            return this.setOfStudents;
        }

        //add teacher
        public void AddTeacher(Teacher teacher)
        {
            this.setOfTeachers.Add(teacher);
        }

        //remove teacher
        public void RemoveTeacher(Teacher teacher)
        {
            this.setOfTeachers.Remove(teacher);
        }

        //get all teacher as a list
        public List<Teacher> GetTeachers()
        {
            return this.setOfTeachers;
        }

        //return comments for current class
        public List<string> Comments { get; }

        /// <summary>
        /// Add a comment to the list of comments that the class ClassOfStudents have.
        /// </summary>
        /// <param name="comment">Adds comment to (list) comments.</param>
        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }
    }
}
