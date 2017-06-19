using System.Runtime.InteropServices;

namespace CarsFactory
{
    using System.Collections.Generic;

    public class Dealer
    {
        private string name;
        private List<City> cities;
        private string city;

        public Dealer()
        {
            
        }

        public Dealer(string name)
        {
            this.name = name;
            this.cities = new List<City>();
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public List<City> Cities
        {
            get { return this.cities; }
            set { this.cities = value; }
        }

        public string City
        {
            get { return this.city; }
            set { this.city = value; }
        }
    }
}
