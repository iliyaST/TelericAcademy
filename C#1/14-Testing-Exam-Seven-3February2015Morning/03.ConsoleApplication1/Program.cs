using System;
using System.IO;
using System.Numerics;

class ConsoleApplication1
{
    static void Main()
    {

        StreamReader sr = new StreamReader("../../input.txt");
        Console.SetIn(sr);

        int counter = 0;
        BigInteger finalProduct = 1;
        BigInteger finalProductAfter10 = 1;
        bool is10 = false;

        while (true)
        {
            string temp = Console.ReadLine();
            if (is10 == true)
            {
                long curProduct10 = 1;
                if (temp == "END")
                {
                    break;
                }
                if (temp == "0" || temp == "")
                {
                    curProduct10 = 1;
                }
                else
                {
                    if (counter % 2 != 0)
                    {
                        for (int i = 0; i < temp.Length; i++)
                        {
                            if (temp[i] != '0')
                            {
                                curProduct10 *= Convert.ToInt64(temp[i].ToString());
                            }
                        }
                    }
                }
                if (curProduct10 != 0)
                {
                    finalProductAfter10 *= curProduct10;
                }
                counter++;
                continue;
            }

            long currentProduct = 1;
            if (temp == "END")
            {
                break;
            }
            if (temp == "0" || temp == "")
            {
                currentProduct = 1;
            }
            else
            {
                if (counter % 2 != 0)
                {
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (temp[i] != '0')
                        {
                            currentProduct *= Convert.ToInt64(temp[i].ToString());
                        }
                    }
                }
            }
            if (currentProduct != 0)
            {
                finalProduct *= currentProduct;
            }
            counter++;
            if (counter == 11)
            {
                is10 = true;
                counter = 1;
            }
        }
        if (is10 == true)
        {
            Console.WriteLine(finalProduct);
            Console.WriteLine(finalProductAfter10);
        }
        else
        {
            Console.WriteLine(finalProduct);
        }
    }
}

