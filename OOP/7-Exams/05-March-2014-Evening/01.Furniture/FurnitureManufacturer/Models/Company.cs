
namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using FurnitureManufacturer.Interfaces;
    using Common;
    using System.Text;
    using System.Linq;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;

        public Company(string name, string regNumber)
        {
            this.Name = name;
            this.RegistrationNumber = regNumber;
            this.Furnitures = new List<IFurniture>();
        }

        public ICollection<IFurniture> Furnitures { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.StringIsNullOrEmpty(value, String.Format(Constants.StringCannotBeNullOrEmpty,
                    nameof(Name)));

                if (value.Length < 5)
                {
                    throw new ArgumentException(String.Format(Constants.StringLength,
                        nameof(Name), Constants.CompanyMinLengthName));
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            set
            {
                Validator.StringIsNullOrEmpty(value, String.Format(Constants.StringCannotBeNullOrEmpty
                    , nameof(RegistrationNumber)));

                Validator.ContainsOnlyNumbers(value, Constants.ContainsNumbers);

                if (value.Length != 10)
                {
                    throw new ArgumentException("Registration number must be exactly 10 letters!");
                }

                this.registrationNumber = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            Validator.IsNull(furniture);

            Furnitures.Add(furniture);
        }

        public string Catalog()
        {
            var sb = new StringBuilder();

            sb.AppendLine(String.Format("{0} - {1} - {2} {3}",
            this.Name,
            this.RegistrationNumber,
            this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
            this.Furnitures.Count != 1 ? "furnitures" : "furniture"
            ));

            foreach (var furniture in Furnitures)
            {
                sb.AppendLine(furniture.ToString());
            }


            return sb.ToString().TrimEnd();
        }

        public IFurniture Find(string model)
        {
            foreach (var furniture in Furnitures)
            {
                if (furniture.Model == model)
                {
                    return furniture;
                }
            }

            return null;
        }

        public void Remove(IFurniture furniture)
        {
            Validator.IsNull(furniture);

            if (Furnitures.Any(x => x == furniture))
            {
                Furnitures.Remove(furniture);
            }
        }
    }
}
