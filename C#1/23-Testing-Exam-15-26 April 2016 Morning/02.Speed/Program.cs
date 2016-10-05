using System;
using System.IO;

class Speeds
{
    static void Main()
    {
        //StreamReader sr = new StreamReader("../../input.txt");
        //Console.SetIn(sr);

        int C = int.Parse(Console.ReadLine());
        int previousCar = int.MaxValue;
        int currentMax = 0;
        int maxSpeed = 0;
        int groupCount = 1;

        for (int i = 0; i < C; i++)
        {
            int car = int.Parse(Console.ReadLine());
            if (previousCar < car)
            {
                groupCount++;
                if (currentMax != 0)
                {
                    currentMax = currentMax + car;
                }
                else
                {
                    currentMax = previousCar + car;
                }
            }
            else
            {
                if (groupCount == 1)
                {
                    currentMax = car;
                }
                else
                {
                    currentMax = 0;
                }
            }

            if(groupCount==2)
            {
                maxSpeed = 0;
                groupCount = int.MinValue;
            }

            previousCar = car;
            if (maxSpeed < currentMax)
            {
                maxSpeed = currentMax;
            }
        }

        Console.WriteLine(maxSpeed);
    }
}

