namespace Problem_2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ConsoleApplication1;

    public class Program
    {    
        public static void Main()
        {
            var operationManager = new EngineOperationManager();

            while (true)
            {
                string data = Console.ReadLine();

                if(data == null)
                {
                    throw new ArgumentException("Invalid command!");
                }

                if (data == "End")
                {
                    break;
                }

                int i = data.IndexOf('(');
                if (i == -1)
                {
                    Console.WriteLine("error!");
                    Environment.Exit(0);
                }

                string command = data.Substring(0, i);
                if (!data.EndsWith(")"))
                {
                    Main();
                }

                string s = data.Substring(i + 1, data.Length - i - 2);
                string[] strings = s.Split(',');

                for (int j = 0; j < strings.Length; j++)
                {
                    strings[j] = strings[j].Trim();
                }

                if (command.StartsWith("AddPhone") && (strings.Length >= 2))
                {
                    operationManager.ParseCommand("AddPhone", strings);
                }
                else if ((command == "ChangePhone") && (strings.Length == 2))
                {
                    operationManager.ParseCommand("ChangePhone", strings);
                }
                else if ((command == "List") && (strings.Length == 2))
                {
                    operationManager.ParseCommand("List", strings);
                }
                else
                {
                    throw new StackOverflowException();
                }             
            }
        }       
    }
}