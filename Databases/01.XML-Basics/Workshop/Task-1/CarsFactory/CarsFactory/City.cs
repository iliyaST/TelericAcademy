namespace CarsFactory
{
    public class City
    {
        private string name;

        public City()
        {
            
        }

        public City(string name)
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
