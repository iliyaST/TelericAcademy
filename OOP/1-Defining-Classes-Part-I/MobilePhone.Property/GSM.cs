using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhone.Property
{
    //model, manufacturer, price, owner, battery characteristics(model, hours idle and hours talk) 
    // and display characteristics(size and number of colors).

    class GSM
    {
        /// <summary>
        /// Fields
        /// </summary>
        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;
        private Battery battery;
        private Display display;
        private static readonly GSM iPhone4SStatic = new GSM("iPhone4S", "Apple", 1500.00M, "ME!!!");
        public List<Call> callHistory = new List<Call>();
        private static readonly decimal pricePerMinute = 0.37m;

        /// <summary>
        /// constructors
        /// </summary>
        /// <param name="model"></param>
        /// <param name="manufacturer"></param>
        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null)
        {

        }

        public GSM(string model, string manufactorer, decimal? price)
            : this(model, manufactorer, price, null)
        {

        }

        public GSM(string model, string manufactorer, decimal? price, string owner)
            : this(model, manufactorer, price, owner, null)
        {

        }

        public GSM(string model, string manufactorer, decimal? price, string owner, Battery battery)
            : this(model, manufactorer, price, owner, battery, null)
        {

        }

        public GSM(string model, string manufactorer, decimal? price, string owner, Battery battery, Display display)
        {
            this.model = model;
            this.manufacturer = manufactorer;
            this.price = price;
            this.owner = owner;
            this.Battery = battery;
            this.Display = display;
        }

        ///<summary>
        ///Properties
        ///</summary>
        public Battery Battery { get; set; }
        public Display Display { get; set; }
        public string Model { get; set; }
        public string Manufacture { get; set; }
        public string Owner { get; set; }

        public static GSM IPhone4SS
        {
            get
            {
                return iPhone4SStatic;
            }
        }

        public decimal? Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be less than 0.");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public void AddCall(Call call)
        {
            callHistory.Add(call);
        }

        public void DeleteCall(Call call)
        {
            callHistory.Remove(call);
        }

        public void ClearHistory()
        {
            callHistory.Clear();
        }

        public decimal? CalculatePrice()
        {
            decimal? totalPrice = 0;
            decimal? duratationOfAllCalls = 0;

            foreach (var item in callHistory)
            {
               duratationOfAllCalls += item.Duration;
            }

            totalPrice = (duratationOfAllCalls / 60) * pricePerMinute;

            return totalPrice;
        }


        /// <summary>
        /// toString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            if (model != null)
            {
                output.AppendLine("------------------");
                output.AppendLine(Model + " characteristics");
                output.AppendLine();
            }

            if (manufacturer != null)
            {
                output.AppendLine("Manufacturer: " + Manufacturer);
            }

            if (price != null)
            {
                output.AppendLine("Price: $" + Price);
            }

            if (owner != null)
            {
                output.AppendLine("Owner: " + Owner);
            }

            if (Display != null && Display.Size != null)
            {
                output.AppendLine("Display size: " + Display.Size + " inches");
            }

            if (Display != null && Display.Colors != null)
            {
                output.AppendLine("Display colors: " + Display.Colors + " colors");
            }

            if (Battery != null && Battery.Type != null)
            {
                output.AppendLine("Battery type: " + Battery.Type);
            }

            if (Battery != null && Battery.Model != null)
            {
                output.AppendLine("Battery model: " + Battery.Model);
            }

            if (Battery != null && Battery.HoursIdle != null)
            {
                output.AppendLine("Hours idle: " + Battery.HoursIdle + " hours");
            }

            if (Battery != null && Battery.HoursTalk != null)
            {
                output.AppendLine("Hours talk: " + Battery.HoursTalk + " hours");
            }

            return output.ToString();

            //return string.Format("{0} characteristics\n\rManufacturer: {1}\n\rPrice: {2}\n\rOwner: {3}\n\rDisplay size: {4}\n\rDisplay colors: {5}\n\rBattery type: {6}\n\rBattery model: {7}\n\rHours idle: {8}\n\rHours talk: {9}\n\r\n\r"
            //, Model, Manufacturer, Price, Owner, Display.Size, Display.Colors, Battery.Type, Battery.Model, Battery.HoursIdle, Battery.HoursTalk);
        }
    }
}

