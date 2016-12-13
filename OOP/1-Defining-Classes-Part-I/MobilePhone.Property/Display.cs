using System;

namespace MobilePhone.Property
{
    class Display
    {
        //fields
        private int? size;
        private int? numberOfColors;

        //constructors
        public Display() : this(null)
        {
        }

        public Display(int? size) : this(size, null)
        {
        }

        public Display(int? size, int? colors)
        {
            this.Size = size;
            this.Colors = colors;
        }

        //properties
        public int? Size
        {
            get { return this.size; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Display size cannot be less than 0.");
                }
                else
                {
                    this.size = value;
                }
            }
        }

        public int? Colors
        {
            get { return this.numberOfColors; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Display size cannot have less than 0 colors.");
                }
                else
                {
                    this.numberOfColors = value;
                }
            }
        }       
    }
}
