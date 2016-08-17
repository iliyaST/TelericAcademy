using System;

class Bittris
{
    static void Main()
    {
        int numberOfCommands = int.Parse(Console.ReadLine());
        string row1 = new string('0', 8);
        string row2 = new string('0', 8);
        string row3 = new string('0', 8);
        string row4 = new string('0', 8);

        //int input = int.Parse(Console.ReadLine());
        //row1 = Convert.ToString(input,2).PadLeft(8,'0');
        //Console.WriteLine(row1);     
        //int row1 = 0;
        //int row2 = 0;
        //int row3 = 0;
        //int row4 = 0;

        for (int i = 0; i < numberOfCommands; i++)
        {
            string temp = Console.ReadLine();
            int tempInput;
            //255 = 11111111
            if (int.TryParse(temp, out tempInput))
            {
                row1 = Convert.ToString(tempInput,2).PadLeft(8,'0');               
            }
            else
            {

            }
        }
    }
}

