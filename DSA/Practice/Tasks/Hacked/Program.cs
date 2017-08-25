using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Businessmen
{
    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public int Position { get; set; }

        public string Name { get; set; }
    }

    public static void Main()
    {
        var people = new List<Person>();

        while (true)
        {
            var command = Console.ReadLine().Split(' ');

            if (command[0] == "End")
            {
                break;
            }
            else if (command[0] == "Append")
            {
                var person = new Person(command[1]);

                var found = people.FindAll(x => x.Name == person.Name)
                    .Select(x => x)
                    .ToArray();

                if (found.Length >= 1)
                {
                    var number = found.Length;
                    person.Name =  String.Format("{0}{1}", person.Name, number);
                }

                people.Add(person);

                Console.WriteLine("OK");
            }
            else if (command[0] == "Serve")
            {
                var count = int.Parse(command[1]);

                if (count > people.Count)
                {
                    Console.WriteLine("Error");
                }
                else
                {
                    var result = new StringBuilder();
                    for (int i = 0; i < count; i++)
                    {
                        var currentPerson = people[0];

                        if (i == count - 1)
                        {
                            result.Append(currentPerson.Name);
                            people.Remove(currentPerson);

                            Console.WriteLine(result);
                            continue;
                        }

                        result.Append(currentPerson.Name + " ");
                        people.Remove(currentPerson);
                    }
                }
            }
            else if (command[0] == "Find")
            {
                var name = command[1];

                var result = people.FindAll(x => x.Name.Contains(name))
                    .Select(x => x)
                    .ToArray();

                Console.WriteLine(result.Length);
            }
            else if (command[0] == "Insert")
            {
                var person = new Person(command[2]);

                var position = int.Parse(command[1]);

                if (position < 0 || position > people.Count)
                {
                    Console.WriteLine("Error");
                }
                else
                {
                    var found = people.FindAll(x => x.Name == person.Name)
                    .Select(x => x)
                    .ToArray();

                    if (found.Length >= 1)
                    {
                        var number = found.Length;
                        person.Name = String.Format("{0}{1}", person.Name, number);
                    }

                    people.Insert(position, person);
                    Console.WriteLine("OK");
                }
            }
        }
    }
}