namespace Homework
{
    using System;

    /// <summary>
    /// This class represents a Chef and cooks with ingredients
    /// </summary>
    public class Chef
    {   
        /// <summary>
        /// Cooks with potato and carrot
        /// </summary>
        public void Cook()
        {
            Bowl bowl = this.GetBowl();

            Potato potato = this.GetPotato();
            Carrot carrot = this.GetCarrot();           

            this.Peel(potato);
            this.Peel(carrot);

            this.Cut(potato);
            this.Cut(carrot);

            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private void Cut(Vegetable potato)
        {
            throw new NotImplementedException();
        }

        private void Peel(Vegetable potato)
        {
            throw new NotImplementedException();
        }

        private Potato GetPotato()
        {
            return new Potato();
        }
    }
}
