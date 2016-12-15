
namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents teacher.
    /// </summary>
    public class Teacher : Person, ICommentable
    {
        private List<Discipline> disciplines = new List<Discipline>();
        private List<string> comments = new List<string>();

        public Teacher(string name)
            : base(name)
        {

        }
        /// <summary>
        /// Initializes new instance of teacher class to the specified name and set of diciplines.
        /// </summary>
        /// <param name="name">Teacher's name</param>
        /// <param name="disciplines">Set of disciplines.</param>
        public Teacher(string name, IEnumerable<Discipline> disciplines)
            : base(name)
        {
            this.disciplines = disciplines.ToList();
        }

        /// <summary>
        /// Adds discipline to the set of disciplines.
        /// </summary>
        /// <param name="discipline"></param>
        public void AddDiscipline(Discipline discipline)
        {
           disciplines.Add(discipline);
        }

        public List<string> Comments { get; }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }
    }
}