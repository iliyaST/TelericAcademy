using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class EngineOperationManager
    {
        private const string Code = "+359";

        private IPhonebookRepository data;
        private StringBuilder input;

        public EngineOperationManager()
        {
            data = new PhonebookRepository();
            input = new StringBuilder();
        }

        public void ParseCommand(string command, string[] parameters)
        {
            if (command == "AddPhone")
            {
                string entryName = parameters[0];
                var phoneNumbers = parameters.Skip(1).ToList();

                for (int i = 0; i < phoneNumbers.Count; i++)
                {
                    phoneNumbers[i] = Convert(phoneNumbers[i]);
                }

                bool flag = data.AddPhone(entryName, phoneNumbers);

                if (flag)
                {
                    Print("Phone entry created.");
                }
                else
                {
                    Print("Phone entry merged");
                }
            }
            else if (command == "ChangePhone")
            {
                Print(string.Empty + data.ChangePhone(Convert(parameters[0]), Convert(parameters[1])) + " numbers changed");
            }
            else
            {
                try
                {
                    var startIndex = int.Parse(parameters[0]);
                    var count = int.Parse(parameters[1]);
                    IEnumerable<Entry> entries = data.ListEntries(startIndex, count);

                    foreach (var entry in entries)
                    {
                        Print(entry.ToString());
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Print("Invalid range");
                }
            }
        }

        public string Convert(string num)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= input.Length; i++)
            {
                sb.Clear();
                foreach (char ch in num)
                {
                    if (char.IsDigit(ch) || (ch == '+'))
                    {
                        sb.Append(ch);
                    }
                }

                if (sb.Length >= 2 && sb[0] == '0' && sb[1] == '0')
                {
                    sb.Remove(0, 1);
                    sb[0] = '+';
                }

                while (sb.Length > 0 && sb[0] == '0')
                {
                    sb.Remove(0, 1);
                }

                if (sb.Length > 0 && sb[0] != '+')
                {
                    sb.Insert(0, Code);
                }
            }

            return sb.ToString();
        }

        private void Print(string text)
        {            
            Console.WriteLine(text);
            input.Clear();
        }
    }
}
