using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace DancingMoves
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int length = numbers.Length;
            List<string> list = new List<string>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "stop")
                {
                    break;
                }
                else
                {
                    list.Add(line);
                }
            }

            double sum = 0;
            int position = 0;
            double result = 0;
            for (int i = 0; i <= list.Count - 1; i++)
            {
                string[] currentDescr = list[i].Split(' ').ToArray();
                int moves = int.Parse(currentDescr[0]);
                string direction = currentDescr[1].ToString();
                int jumps = int.Parse(currentDescr[2]);

                for (int j = 0; j <= moves - 1; j++)
                {
                    if (direction == "right")
                    {
                        position += jumps;
                        if (position > numbers.Length - 1)
                        {
                            position = position % length;
                        }
                        sum += numbers[position];
                    }
                    else if (direction == "left")
                    {
                        position -= jumps;
                        if (position < 0)
                        {
                            position = -position;

                            position = length - (position % numbers.Length);

                        }
                        sum += numbers[position];
                    }
                }
            }
            result = sum / 4;
            Console.WriteLine("{0:F1}", result);
        }
    }
}