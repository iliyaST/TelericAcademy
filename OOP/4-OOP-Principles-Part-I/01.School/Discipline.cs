
namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a school discipline.
    /// </summary>
    public class Discipline:ICommentable
    {
        private List<string> comments = new List<string>();
        /// <summary>
        /// Initializes new instance of discipline class to the specified name, number of lectures and number of exercises.
        /// </summary>
        /// <param name="name">Discipline name.</param>
        /// <param name="lectures">Number of lectures.</param>
        /// <param name="exercises">Number of exercises.</param>
        public Discipline(string name, int lectures, int exercises)
        {
            this.Name = name;
            this.NumberOfExercises = lectures;
            this.NumberOfExercises = exercises;
        }

        /// <summary>
        /// Gets the name of the discipline.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets number of lectures.
        /// </summary>
        public int NumberOfLectures { get; private set; }

        /// <summary>
        /// Gets numbers of exercises.
        /// </summary>
        public int NumberOfExercises { get; private set; }

        public List<string> Comments { get; }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }
    }
}
