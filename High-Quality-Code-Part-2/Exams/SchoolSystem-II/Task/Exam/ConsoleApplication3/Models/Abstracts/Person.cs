namespace SchoolSystem.CLI.Models.Abstractions
{
    using SchoolSystem.CLI.Models.Contracts;

    public abstract class Person : IPerson
    {
        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
