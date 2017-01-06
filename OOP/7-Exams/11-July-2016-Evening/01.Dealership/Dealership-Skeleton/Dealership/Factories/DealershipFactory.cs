using Dealership.Contracts;
using System;
using Dealership.Models;
using Dealership.Common.Enums;
using Dealership.Common;

namespace Dealership.Factories
{
    public class DealershipFactory : IDealershipFactory
    {
        public IVehicle CreateCar(string make, string model, decimal price, int seats)
        {
            IVehicle vehicle = new Car(make, model, price, seats);

            Validator.ValidateNull(vehicle, Constants.VehicleCannotBeNull);

            return vehicle;
        }

        public IVehicle CreateMotorcycle(string make, string model, decimal price, string category)
        {
            IVehicle vehicle = new Motorcycle(make, model, price, category);

            Validator.ValidateNull(vehicle, Constants.VehicleCannotBeNull);

            return vehicle;
        }

        public IVehicle CreateTruck(string make, string model, decimal price, int weightCapacity)
        {
            IVehicle vehicle = new Truck(make, model, price, weightCapacity);

            Validator.ValidateNull(vehicle, Constants.VehicleCannotBeNull);

            return vehicle;
        }

        public IUser CreateUser(string username, string firstName, string lastName, string password, string role)
        {
            IUser user = new User(username, firstName, lastName, password, role);

            if (user == null)
            {
                throw new ArgumentNullException("User cannot be null!");
            }

            return user;
        }

        public IComment CreateComment(string content)
        {
            IComment comment = new Comment(content);

            Validator.ValidateNull(comment, Constants.CommentCannotBeNull);

            return comment;
        }
    }
}
