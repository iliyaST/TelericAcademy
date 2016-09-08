using System;

class Sheets
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        bool isA0 = false;
        bool isA1 = false;
        bool isA2 = false;
        bool isA3 = false;
        bool isA4 = false;
        bool isA5 = false;
        bool isA6 = false;
        bool isA7 = false;
        bool isA8 = false;
        bool isA9 = false;
        bool isA10 = false;
        //int A10 = 1;
        //int A9 = 2;
        //int A8 = 4;
        //int A7 = 8;
        //int A6 = 16;
        //int A5 = 32;
        //int A4 = 64;
        //int A3 = 128;
        //int A2 = 256;
        //int A1 = 512;
        //int A0 = 1024;
        while (N > 0)
        {
            if (N < 1024)
            {
                if (N == 1)
                {
                    N /= 2;
                    isA10 = true;
                }
                if (N >= 2 && N < 4)
                {
                    if (N == 2)
                    {
                        N /= 3;
                        isA9 = true;
                        break;
                    }
                    else
                    {
                        N %= 2;
                        isA9 = true;
                    }
                }
                if (N >= 4 && N < 8)
                {
                    if (N == 4)
                    {
                        N /= 5;
                        isA8 = true;
                        break;
                    }
                    else
                    {
                        N %= 4;
                        isA8 = true;
                    }
                }
                if (N >= 8 && N < 16)
                {
                    if (N == 8)
                    {
                        N /= 9;
                        isA7 = true;
                        break;
                    }
                    else
                    {
                        N %= 8;
                        isA7 = true;
                    }

                }
                if (N >= 16 && N < 32)
                {
                    if (N == 16)
                    {
                        N /= 17;
                        isA6 = true;
                        break;
                    }
                    else
                    {
                        N %= 16;
                        isA6 = true;
                    }
                }
                if (N >= 32 && N < 64)
                {
                    if (N == 32)
                    {
                        N /= 33;
                        isA5 = true;
                        break;
                    }
                    else
                    {
                        N %= 32;
                        isA5 = true;
                    }
                }
                if (N >= 64 && N < 128)
                {
                    if (N == 64)
                    {
                        N /= 65;
                        isA4 = true;
                        break;
                    }
                    else
                    {
                        N %= 64;
                        isA4 = true;
                    }
                }
                if (N >= 128 && N < 256)
                {
                    if (N == 128)
                    {
                        N /= 129;
                        isA3 = true;
                        break;
                    }
                    else
                    {
                        N %= 128;
                        isA3 = true;
                    }
                }
                if (N >= 256 && N < 512)
                {
                    if (N == 2)
                    {
                        N /= 257;
                        isA2 = true;
                        break;
                    }
                    else
                    {
                        N %= 256;
                        isA2 = true;
                    }
                }
                if (N >= 512 && N < 1024)
                {
                    if (N == 512)
                    {
                        N /= 513;
                        isA1 = true;
                        break;
                    }
                    else
                    {
                        N %= 512;
                        isA1 = true;
                    }
                }
            }
            else if (N >= 1024)
            {
                if (N == 1024)
                {
                    N /= 1025;
                    isA0 = true;
                    break;
                }
                else
                {
                    N %= 1024;
                    isA0 = true;
                }
            }
        }
        if (isA0 == false)
        {
            Console.WriteLine("A0");
        }
        if (isA1 == false)
        {
            Console.WriteLine("A1");
        }
        if (isA2 == false)
        {
            Console.WriteLine("A2");
        }
        if (isA3 == false)
        {
            Console.WriteLine("A3");
        }
        if (isA4 == false)
        {
            Console.WriteLine("A4");
        }
        if (isA5 == false)
        {
            Console.WriteLine("A5");
        }
        if (isA6 == false)
        {
            Console.WriteLine("A6");
        }
        if (isA7 == false)
        {
            Console.WriteLine("A7");
        }
        if (isA8 == false)
        {
            Console.WriteLine("A8");
        }
        if (isA9 == false)
        {
            Console.WriteLine("A9");
        }
        if (isA10 == false)
        {
            Console.WriteLine("A10");
        }
    }
}

