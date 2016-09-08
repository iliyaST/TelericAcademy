using System;
using System.Numerics;

class NeuronMapping
{
    static void Main()
    {
        string[,] array = new string[100, 32];
        int counter = 0;
        int row = 0;


        while (true)
        {
            long tempInput = long.Parse(Console.ReadLine());
            string temp = Convert.ToString(tempInput, 2).PadLeft(32, '.');

            if (tempInput == -1)
            {
                break;
            }

            for (int j = 0; j < temp.Length; j++)
            {
                if (temp[j] == '0')
                {
                    array[row, j] = ".";
                    continue;
                }
                array[row, j] = temp[j].ToString();

            }
            counter++;
            row++;
        }

        //for (int i = 0; i < counter; i++)
        //{
        //    for (int j = 0; j < 32; j++)
        //    {
        //        Console.Write(array[i, j] + " ");
        //    }
        //    Console.WriteLine();
        //}
        //Console.WriteLine();


        for (int i = 0; i < counter; i++)
        {
            for (int j = 0; j < 32; j++)
            {
                if(array[i,j]=="1"&&j==31)
                {
                    array[i, j] = "0";
                }
                if (array[i, j] == "1")
                {
                    if (array[i, j + 1] == "1")
                    {
                        array[i, j] = ".";
                    }
                    else
                    {
                        array[i, j] = ".";
                        int interval = 0;
                        int currentPosition = 0;
                        for (int x = j; x < 32; x++)
                        {
                            if (array[i, x] == "1")
                            {
                                currentPosition = x;
                                interval++;
                                break;
                            }
                        }
                        if (interval == 0)
                        {
                            continue;
                        }
                        else
                        {
                            for (int y = j + 1; y < currentPosition; y++)
                            {
                                array[i, y] = "h";
                            }
                            interval = 0;
                            currentPosition = 0;
                        }
                    }
                }
            }
        }


        for (int i = 0; i < counter; i++)
        {
            for (int j = 0; j < 32; j++)
            {
                if (array[i, j] == "h")
                {
                    array[i, j] = "1";
                }
                if (array[i, j] == ".")
                {
                    array[i, j] = "0";
                }
            }
        }
        //Console.WriteLine("####################");
        string temp1 = "";
        for (int i = 0; i < counter; i++)
        {
            temp1 = "";
            for (int j = 0; j < 32; j++)
            {
                temp1 += array[i, j];
            }          
            Console.WriteLine(Convert.ToInt32(temp1, 2));
        }

        //Console.WriteLine("#####################");


        //for (int i = 0; i < counter; i++)
        //{
        //    for (int j = 0; j < 32; j++)
        //    {
        //        Console.Write(array[i, j] + " ");
        //    }
        //    Console.WriteLine();
        //}
    }
}


