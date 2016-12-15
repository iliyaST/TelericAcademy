
namespace Humans
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Student : Human
    {
        /// <summary>
        /// Fields
        /// </summary>
        private int grade;

        /// <summary>
        /// Initializes new instance of student class to a sepcified firstname, lastname and grade.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="grade"></param>
        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        /// <summary>
        /// Properties
        /// </summary>
        public int Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                if (value < 2 && value > 6)
                {
                    throw new ArgumentException("Grade can be between 2 and 6!");
                }

                this.grade = value;
            }
        }
    }
}
