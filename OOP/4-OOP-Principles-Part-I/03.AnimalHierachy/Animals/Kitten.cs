
namespace AnimalHierachy
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents a kitten.
    /// </summary>
    class Kitten : Cat
    {
        /// <summary>
        /// Initializes new instance of the class kitten to the specified age and name of the kitten.
        /// </summary>
        /// <param name="age">Kitten's age.</param>
        /// <param name="name">Kitten's name.</param>
        public Kitten(string name, int age)
            : base(name, "female", age)
        {
        }
    }
}