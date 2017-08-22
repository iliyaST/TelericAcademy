using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
    public class Program
    {
        public class Player
        {
            public Player(string name, string type, int age, int position)
            {
                this.Name = name;
                this.Type = type;
                this.Age = age;
                this.Position = position;
            }

            public string Name { get; set; }
            public string Type { get; set; }
            public int Age { get; set; }
            public int Position { get; set; }
        }


        public static void Main(string[] args)
        {
            var database = new List<Player>();

            while (true)
            {
                var input = Console.ReadLine().Split(' ');

                if (input[0] == "end")
                {
                    break;
                }

                if (input[0] == "add")
                {
                    var player = new Player(input[1], input[2], int.Parse(input[3]), int.Parse(input[4]));

                    var insertIndex = int.Parse(input[4]) - 1;
                    if (insertIndex == database.Count)
                    {
                        database.Add(player);
                    }
                    else
                    {
                        database.Insert(insertIndex, player);
                    }

                    Console.WriteLine("Added player {0} to position {1}", input[1], input[4]);
                }
                else if (input[0] == "find")
                {
                    var searchedType = input[1];
                    var players = database
                        .FindAll(x => x.Type == searchedType)
                        .Select(x => x)
                        .ToArray()
                        .OrderBy(x => x.Name)
                        .ThenByDescending(x => x.Age)
                        .ToArray();

                    var result = new StringBuilder();
                    result.Append(string.Format("Type {0}: ", searchedType));

                    for (int i = 0; i < players.Count(); i++)
                    {
                        if (i == players.Count() - 1)
                        {
                            result.Append(players[i].Name + "(" + players[i].Age + ")");
                            break;
                        }

                        result.Append(players[i].Name + "(" + players[i].Age + ");" + " ");
                    }

                    Console.WriteLine(result);
                }
                else if (input[0] == "ranklist")
                {
                    var result = new StringBuilder();
                    var start = int.Parse(input[1]) - 1;
                    var end = int.Parse(input[2]);

                    for (int i = start; i < end; i++)
                    {
                        if (i == end - 1)
                        {
                            result.Append(i + 1 + ". " + database[i].Name + "(" + database[i].Age + ")");
                            break;
                        }

                        result.Append(i + 1 + ". " + database[i].Name + "(" + database[i].Age + ");" + " ");
                    }

                    Console.WriteLine(result);
                }
            }
        }
    }
}
