

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;

namespace CarsFactory
{
    public class CarJsonModel
    {
        public string Model { get; set; }

        public Dealer Dealer { get; set; }

        public string ManufacturerName { get; set; }

        public decimal Price { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public int Year { get; set; }

        /* Other properties */
        public static Func<CarJsonModel, Car> FromJsonModel
        {
            get
            {
                return jsomModel => new Car
                {
                    Model = jsomModel.Model,
                    Dealer = new Dealer
                    {
                        Name = jsomModel.Dealer.Name,
                        Cities = new List<City> {new City {Name = jsomModel.Dealer.City}}
                    },
                    Manufacturer = new Manufacturer
                    {
                        Name = jsomModel.ManufacturerName
                    },
                    Price = jsomModel.Price,
                    TransmissionType = jsomModel.TransmissionType,
                    Year = jsomModel.Year
                };
            }
        }

        
    }
}
