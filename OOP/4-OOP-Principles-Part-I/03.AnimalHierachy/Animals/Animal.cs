
namespace AnimalHierachy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    abstract class Animal : ISound
    {
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Sets animal properties. Can be used only by derived classes.
        /// </summary>
        /// <param name="age"></param>
        /// <param name="sex"></param>
        /// <param name="name"></param>
        protected Animal(int age, string sex, string name)
        {
            this.Age = age;
            this.Sex = sex;
            this.Name = name;
        }

        /// <summary>
        /// Each animal must have it's own sound.
        /// </summary>
        public abstract void MakeSound();
    }
}
