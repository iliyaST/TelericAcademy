
namespace AnimalHierachy
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents animal dog.
    /// </summary>
    class Dog : Animal
    {

        /// <summary>
        /// Initializes new instance of the dog class to the specified age, sex and name of the dog.
        /// </summary>
        /// <param name="age">Dog's age</param>
        /// <param name="sex">Dog's sex</param>
        /// <param name="name">Dog's name</param>
        public Dog(string sex, string name, int age)
            : base(age, sex, name)
        {
        }

        /// <summary>
        /// Makes the animal to produce it's own sound.
        /// </summary>
        public override void MakeSound()
        {
            Console.WriteLine("woof-woof");
        }
    }
}