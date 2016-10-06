using System;

class Busses
{
    static void Main()
    {
        int C = int.Parse(Console.ReadLine());
        int[] speeds = new int[C];
        int groupsCount = 0;

        for (int i = 0; i < C; i++)
        {
            int S = int.Parse(Console.ReadLine());
            speeds[i] = S;
        }

        for (int i = 0; i < C; i++)
        {
            if ((i == C - 1) && speeds[i - 1] >= speeds[i])
            {
                groupsCount++;
                break;
            }
            if (speeds[i + 1] > speeds[i])
            {
                speeds[i + 1] = speeds[i];
            }
            else
            {
                groupsCount++;
            }
        }

        Console.WriteLine(groupsCount);
    }
}

