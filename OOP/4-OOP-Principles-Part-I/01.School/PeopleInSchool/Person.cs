
namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Person
    {
        /// <summary>
        /// Initializes name for every person object. Can be used only by derived classes.
        /// </summary>
        /// <param name="name">Name for any person object in school.</param>
        protected Person(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the name of a person.
        /// </summary>
        public string Name { get; private set; }
    }
}
