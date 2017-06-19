namespace CarsFactory
{
    public class Car
    {
        public int Year { get; set; }    

        public string Model { get; set; }

        public decimal Price { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public Dealer Dealer { get; set; }
    }
}