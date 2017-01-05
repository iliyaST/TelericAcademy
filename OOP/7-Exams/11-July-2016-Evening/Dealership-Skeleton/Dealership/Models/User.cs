using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Common.Enums;
using Dealership.Common;
using Dealership.Engine;

namespace Dealership.Models
{
    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private string username;
        private string password;
        private const string UsernamePattern = "^[A-Za-z0-9]+$";
        private const string PasswordPattern = "^[A-Za-z0-9@*_-]+$";
        private const int MinNameLength = 2;
        private const int MaxNameLength = 20;
        private const int MinPasswordLength = 5;
        private const int MaxPasswordLength = 30;
        private const string InvalidPassword = "Password contains invalid symbols!";
        private const string StringMustBeBetweenMinAndMax = "Username must be between 2 and 20 characters long!";
        private const string StringMustBeBetweenMinAndMaxA = "{0} must be between {1} and {2} characters long!";
        private IList<IVehicle> vehicles;
        private const int VehicleCapacityForNonVips = 5;

        public User(string username, string firstName, string lastName, string password, string role)
        {
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Role = (Role)Enum.Parse(typeof(Role), role);
            this.vehicles = new List<IVehicle>();
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                Validator.ValidateIntRange(value.Length, MinNameLength, MaxNameLength,
                    StringMustBeBetweenMinAndMax);

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                Validator.ValidateIntRange(value.Length, MinNameLength, MaxNameLength,
                   StringMustBeBetweenMinAndMax);

                this.lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                Validator.ValidateIntRange(value.Length, MinPasswordLength, MaxPasswordLength
                    , String.Format(StringMustBeBetweenMinAndMaxA, nameof(Password), MinPasswordLength, MaxPasswordLength));
                Validator.ValidateSymbols(value, PasswordPattern, InvalidPassword);

                this.password = value;
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                Validator.ValidateIntRange(value.Length, MinNameLength, MaxNameLength, "Username must be between 2 and 20 characters long!");
                Validator.ValidateSymbols(value, UsernamePattern, "Username contains invalid symbols!");
                this.username = value;
            }
        }

        public Role Role { get; }

        public IList<IVehicle> Vehicles
        {
            get
            {
                return this.vehicles;
            }
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            vehicleToAddComment.Comments.Add(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            if (this.Role == Role.Admin)
            {
                throw new ArgumentException(Constants.AdminCannotAddVehicles);
            }
            else if (this.Role != Role.VIP)
            {
                if (vehicles.Count == 5)
                {
                    throw new ArgumentException(String.Format(Constants.NotAnVipUserVehiclesAdd
                        , Constants.MaxVehiclesToAdd));
                }
                else
                {
                    vehicles.Add(vehicle);
                }
            }
            else
            {
                vehicles.Add(vehicle);
            }

        }

        public string PrintVehicles()
        {
            var sb = new StringBuilder();
            var indexer = 0;
            sb.AppendLine(String.Format("--USER {0}--", this.Username));

            foreach (var vehicle in vehicles)
            {
                indexer += 1;
                string vehicleType = vehicle.Type.ToString();
                //1.Motorcycle:
                sb.AppendLine(string.Format("{0}.{1}:", indexer, vehicleType));

                sb.Append(vehicle.ToString());
                sb.AppendLine("    --COMMENTS--");
            }

            return sb.ToString();
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            vehicleToRemoveComment.Comments.Remove(commentToRemove);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            vehicles.Remove(vehicle);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(String.Format("Username: {0}, FullName: {1} {2}, Role: {3}",
              this.Username, this.FirstName, this.LastName, this.Role));

            return sb.ToString();
        }
    }
}
