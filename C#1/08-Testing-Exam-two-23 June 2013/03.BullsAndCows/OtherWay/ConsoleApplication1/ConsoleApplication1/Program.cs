using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int secretNumber = int.Parse(Console.ReadLine());
            int bulls = int.Parse(Console.ReadLine());
            int cows = int.Parse(Console.ReadLine());

            //1483
            int[] array = new int[4];

            array[3] = secretNumber % 10;
            array[2] = secretNumber / 10 % 10;
            array[1] = secretNumber / 100 % 10;
            array[0] = secretNumber / 1000 % 10;

            //bulls = 2;
            //cows = 1;
            if (bulls != 0)
            {
                int bullsC = 4 - bulls;
                int counter = 0;
                int cowsC = 4 - cows;
                int counter1 = 0;

                while (counter <= bullsC)
                {
                    //1483
                    while (counter1 <= cowsC)
                    {

                        counter1++;
                    }

                    counter++;
                }
            }


            //else
            //{
            //    if (cows == 0)
            //    {

            //    }
            //    else
            //    {

            //    }
            //}

        }
    }
}
