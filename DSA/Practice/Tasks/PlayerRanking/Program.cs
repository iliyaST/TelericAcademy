using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace PlayerRanking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var allPlayersByPosition = new BigList<Player>();
            var sortedPlayers = new Dictionary<string, SortedSet<Player>>();
            var result = new StringBuilder();

            var command = Console.ReadLine();

            while (command != "end")
            {
                var newCommand = new Command();

                newCommand.ParseCommand(command);

                switch (newCommand.Name)
                {
                    case "add":
                        var name = newCommand.Parts[0];
                        var type = newCommand.Parts[1];
                        var age = newCommand.Parts[2];
                        var position = int.Parse(newCommand.Parts[3]);

                        var player = new Player(name, type, age);

                        if (!sortedPlayers.ContainsKey(type))
                        {
                            sortedPlayers.Add(type, new SortedSet<Player>());
                        }

                        sortedPlayers[type].Add(player);
                        allPlayersByPosition.Insert(position - 1, player);

                        result.AppendLine(string.Format("Added player {0} to position {1}",
                            player.Name, position));

                        break;

                    case "find":
                        var searchedType = newCommand.Parts[0];

                        if (!sortedPlayers.ContainsKey(searchedType))
                        {
                            result.AppendLine("Type " + searchedType + ": ");
                        }
                        else
                        {
                            var resultPlayers = sortedPlayers[searchedType].Take(5).ToArray();

                            result.Append("Type " + searchedType + ": ");

                            for (int i = 0; i < resultPlayers.Count(); i++)
                            {
                                if (i == resultPlayers.Count() - 1)
                                {
                                    result.Append(resultPlayers[i].ToString());
                                    result.AppendLine();
                                    continue;
                                }

                                result.Append(resultPlayers[i].ToString() + "; ");
                            }
                        }

                        break;

                    case "ranklist":
                        var start = int.Parse(newCommand.Parts[0]) - 1;
                        var end = int.Parse(newCommand.Parts[1]);
                        var array = new List<Player>();

                        for (int i = start; i < end; i++)
                        {
                            array.Add(allPlayersByPosition[i]);
                        }

                        for (int i = 0; i < array.Count; i++)
                        {
                            if (i == array.Count - 1)
                            {
                                result.Append(i + 1 + ". " + array[i].ToString());
                                result.AppendLine();
                                continue;
                            }

                            result.Append(i + 1 + ". " + array[i].ToString() + "; ");
                        }

                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(result.ToString().Trim());
        }

        public class Player : IComparable<Player>
        {
            public Player(string name, string type, string age)
            {
                this.Name = name;
                this.Type = type;
                this.Age = int.Parse(age);
            }

            public string Name { get; set; }

            public int Age { get; set; }

            public string Type { get; set; }

            public int CompareTo(Player other)
            {
                var result = this.Name.CompareTo(other.Name);

                if (result == 0)
                {
                    return this.Age.CompareTo(other.Age) * -1;
                }

                return result;
            }

            public override string ToString()
            {
                return string.Format("{0}({1})", this.Name, this.Age);
            }
        }

        private class Command
        {
            public Command()
            {
                this.Parts = new List<string>();
            }

            public string Name { get; set; }

            public List<string> Parts { get; set; }

            public void ParseCommand(string command)
            {
                var parsed = command.Split(' ');

                if (command.Length > 1)
                {
                    this.Name = parsed[0];

                    for (int i = 1; i < parsed.Length; i++)
                    {
                        this.Parts.Add(parsed[i]);
                    }
                }
                else
                {
                    this.Name = parsed[0];
                }
            }
        }
    }
}
