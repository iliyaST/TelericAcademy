namespace Homework
{
    using System.Collections.Generic;

    public class Bowl : IBowl
    {
        public ICollection<Vegetable> Vegetables { get; set; }

        public void Add(Vegetable vegetable)
        {
            this.Vegetables.Add(vegetable);
        }
    }
}
