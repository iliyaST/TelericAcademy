
namespace AnimalHierachy
{
    using System;

    /// <summary>
    /// Represents frog animal.
    /// </summary>
    class Frog : Animal
    {
        /// <summary>
        /// Initializes new instance of the frog class to the specified age, sex and name of the frog.
        /// </summary>
        /// <param name="age"></param>
        /// <param name="sex"></param>
        /// <param name="name"></param>
        public Frog(string sex, string name, int age)
            : base(age, sex, name)
        {
        }

        /// <summary>
        /// Makes the animal to produce it's own sound.
        /// </summary>
        public override void MakeSound()
        {
            Console.WriteLine("ribbit");
        }
    }
}