namespace SchoolSystem.CLI.Models
{
    using System;
    using Enums;
    using SchoolSystem.CLI.Models.Contracts;

    public class Mark : IMark
    {
        private const string ValueMustBeInRange = "Value must be between 2 and 6";
        private float value;
        private Subject subject;

        public Mark(Subject sbject, float value)
        {
            this.Subject = sbject;
            this.Value = value;
        }

        public float Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value < 2 || value > 6)
                {
                    throw new ArgumentException("Value must be between 2 and 6");
                }

                this.value = value;
            }
        }

        public Subject Subject
        {
            get
            {
                return this.subject;
            }

            set
            {
                this.subject = value;
            }
        }
    }
}
