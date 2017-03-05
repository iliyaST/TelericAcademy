namespace NamingIdentifiersHomework
{
    public class HumanCreator
    {
        public enum Sex
        {
            male,
            female
        }

        public void CreateHuman(int magicalNumber)
        {
            var newPerson = new Human();

            newPerson.Age = magicalNumber;

            if (magicalNumber % 2 == 0)
            {
                newPerson.Name = "John";
                newPerson.Sex = Sex.male;
            }
            else
            {
                newPerson.Name = "Ann";
                newPerson.Sex = Sex.female;
            }
        }
        
        public class Human
        {
            public Sex Sex { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }
        }     
    }
}
