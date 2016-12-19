
namespace PersonClass
{
    using System;

    /// <summary>
    /// Initialize a person
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Fields
        /// </summary>
        private int? age;

        /// <summary>
        /// Istance of person with only name
        /// </summary>
        /// <param name="name"></param>
        public Person(string name)
            : this(name, null)
        {
            this.Name = name;
        }

        /// <summary>
        ///  Istance of person with name and age
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        public Person(string name, int? age)
        {
            this.Name = name;
            this.Age = age;
        }

        /// <summary>
        /// Properties
        /// </summary>
        public string Name { get; set; }

        public int? Age
        {
            get
            {
                return this.age;
            }
            set
            {
                try
                {
                    if (value == null)
                    {
                        throw new ArgumentException("Age is not specified!");
                    }
                    this.age = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Ovveride toString method :)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (this.Age != null)
            {
                return String.Format("{0} must have age!", this.Name);
            }
            else
            {
                return this.Name + " is " + this.Age + "years old.";
            }
        }
    }
}
