using System;

namespace MobilePhone.Property
{
    class Battery
    {
        //fields 
        private string model;
        private int? hoursIdle;
        private int? hoursTalk;
        private BatteryType type;

        //constructors
        public Battery(string model)
            : this(model, null)
        {
        }

        public Battery(string model, int? hoursIdle)
            : this(model, hoursIdle, null)
        {
        }

        public Battery(string model, int? hoursIdle, int? hoursTalk)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }

        //properties
        public string Model { get; set; }
        public BatteryType Type { get; set; }

        public int? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("hours can not be less than 0!");
                }
                else
                {
                    this.hoursIdle = value;
                }
            }
        }

        public int? HoursTalk
        {
            get { return this.hoursTalk; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Hours talk cannot be less than 0.");
                }
                else
                {
                    this.hoursTalk = value;
                }
            }
        }        
    }
}
