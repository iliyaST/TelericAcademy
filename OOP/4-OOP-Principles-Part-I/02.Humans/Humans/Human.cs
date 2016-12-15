
namespace Humans
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Human
    {
        /// <summary>
        /// Constructor for basic characteristics initialization. Used only from derived classes.
        /// </summary>
        /// <param name="firstName">First name of a human.</param>
        /// <param name="lastName">Last name of a human.</param>
        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        /// <summary>
        /// Properties
        /// </summary>
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

    }
}
