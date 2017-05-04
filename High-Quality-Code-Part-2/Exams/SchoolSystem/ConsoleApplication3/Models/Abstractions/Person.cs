namespace School.Models.Abstractions
{
    using School.Models.Common;

    public abstract class Person
    {
        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                Validator.StringLength(value, Constants.MinNameLength, Constants.MaxNameLength, Constants.StringMustBeBetweenMinAndMax);

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
                Validator.StringLength(value, Constants.MinNameLength, Constants.MaxNameLength, Constants.StringMustBeBetweenMinAndMax);

                this.lastName = value;
            }
        }
    }
}
