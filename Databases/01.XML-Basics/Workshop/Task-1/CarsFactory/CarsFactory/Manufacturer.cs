namespace CarsFactory
{
    public class Manufacturer
    {
        private string name;

        public Manufacturer()
        {

        }

        public Manufacturer(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;

            }
            set { this.name = value; }
        }
    }
}
