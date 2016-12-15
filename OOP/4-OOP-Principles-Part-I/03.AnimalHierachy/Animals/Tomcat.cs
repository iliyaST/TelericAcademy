
namespace AnimalHierachy
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents a tomcat.
    /// </summary>
    class Tomcat : Cat
    {
        /// <summary>
        /// Initializes new instance of the tomcat class to the specified age and name of the tomcat.
        /// </summary>
        /// <param name="age"></param>
        /// <param name="name"></param>
        public Tomcat( string name, int age)
            : base(name,"male", age)
        {
        }
    }
}