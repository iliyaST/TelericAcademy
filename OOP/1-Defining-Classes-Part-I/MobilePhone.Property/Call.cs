using System;

namespace MobilePhone.Property
{
    class Call
    {
        private DateTime dateOfCall;
        private string dialledNumber;
        private long? callDuratation;

        public DateTime DateTime
        {
            get
            {
                return this.dateOfCall;
            }
            private set
            {
                // Validation
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Datetime of the call cannot be in the future.");
                }
                this.dateOfCall = value;
            }
        }

        /// <summary>
        /// Gets the duration of the call.
        /// </summary>
        public long? Duration
        {
            get
            {
                return this.callDuratation;
            }
            private set
            {
                // Validation
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Duration of the call cannot be negative number.");
                }
                this.callDuratation = value;
            }
        }

        /// <summary>
        /// Gets the number of the addressee.
        /// </summary>
        public string DialedNumber
        {
            get
            {
                return this.dialledNumber;
            }
            private set
            {
                // Validation
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Dialed number cannot be null, empty or white space.");
                }
                this.dialledNumber = value;
            }
        }

        public Call(DateTime dateOfCall, string dialledNumber, long callDuratation)
        {
            this.DateTime = dateOfCall;
            this.DialedNumber = dialledNumber;
            this.Duration = callDuratation;
        }
    }
}
