
namespace AnimalHierachy
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents cat animal.
    /// </summary>
    class Cat : Animal
    {
        /// <summary>
        /// Initializes new instance of the cat class to the specified age, sex and name of the cat.
        /// </summary>
        /// <param name="age">Cat's age</param>
        /// <param name="sex">Cat's sex</param>
        /// <param name="name">Cat's name</param>
        public Cat(string sex, string name, int age)
            : base(age, sex, name)
        {
        }

        /// <summary>
        /// Makes the animal to produce it's own sound.
        /// </summary>
        public override void MakeSound()
        {
            Console.WriteLine("meow");
        }
    }
}