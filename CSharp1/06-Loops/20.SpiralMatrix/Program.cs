using System;
/*
Problem 19.** Spiral Matrix
Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20) and prints 
a matrix holding the numbers from 1 to n*n in the form of square spiral like in the examples below.
 array[0, 0] = 1;
 array[0, n - 1] = n;
 array[n, n] = n * 2 - 1;
 array[n, 0] = array[3, 3] + 3;
*/
class SpiralMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] array;
        array = new int[n, n];
        int maxRotations = n * n;
        string direction = "right";
        int cow = 0;
        int row = 0;

        for (int i = 1; i <= maxRotations; i++)
        {
            if (direction == "right" && (cow > n - 1 || array[row, cow] != 0))
            {
                direction = "down";
                cow--;
                row++;
            }
            if (direction == "down" && ((row > n - 1) || array[row, cow] != 0))
            {
                direction = "left";
                row--;
                cow--;
            }
            if (direction == "left" && ((cow < 0) || array[row, cow] != 0))
            {
                direction = "up";
                cow++;
                row--;
            }
            if (direction == "up" && ((cow < 0) || array[row, cow] != 0))
            {
                direction = "right";
                row++;
                cow++;
            }

            array[row, cow] = i;

            if (direction == "right")
            {
                cow++;
            }
            if (direction == "down")
            {
                row++;
            }
            if (direction == "left")
            {
                cow--;
            }
            if (direction == "up")
            {
                row--;
            }

        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

