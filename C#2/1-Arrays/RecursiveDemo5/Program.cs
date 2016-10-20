using System;

class Permutations
{
    static int N;
    static int[] arrayE;
    static int[] combArray;

    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        combArray = new int[N];
        arrayE = new int[N];
        //n = 3;
        for (int i = 0; i < N; i++)
        {
            arrayE[i] = i + 1; // 1 2 3 
        }

        variations(0, 0);
    }

    public static void variations(int c, int index)
    {
        if (c == arrayE.Length)
        {
            for (int i = 0; i < arrayE.Length; i++)
            {
                Console.Write(combArray[i] + " ");
            }
            Console.WriteLine();
            return;
        }

        for (int i = index; i < arrayE.Length; i++)
        {
            combArray[c] = arrayE[i];
            variations(c + 1, i + 1);
        }
    }
}

