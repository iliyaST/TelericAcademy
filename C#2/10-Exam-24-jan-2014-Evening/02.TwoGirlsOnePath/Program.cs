using System;
using System.Numerics;

class TwoGirlsOnePath
{
    static void Main()
    {
        //4 17 4 2 7 11 3 2
        //Dolly
        //13 20
        string[] input = Console.ReadLine().Split(new char[] { ' ' });
        BigInteger mollyResult = 0;
        BigInteger dollyResult = 0;
        bool mollyReachedEmptyCell = false;
        bool dollyReachedEmptyCell = false;
        int mollyStartPos = 0;
        int dollyStartPos = input.Length - 1;

        while (true)
        {

            BigInteger currentMollyFlowers = 0;
            BigInteger currentDollyFlowers = 0;
            //if empty cell is reached
            if (BigInteger.Parse(input[mollyStartPos].ToString()) == 0)
            {
                mollyReachedEmptyCell = true;
                if (BigInteger.Parse(input[dollyStartPos].ToString()) == 0)
                {
                    dollyReachedEmptyCell = true;
                }
                else
                {
                    currentDollyFlowers = BigInteger.Parse(input[dollyStartPos].ToString());
                    dollyResult += currentDollyFlowers;
                }
                break;
            }
            else if (BigInteger.Parse(input[dollyStartPos].ToString()) == 0)
            {
                dollyReachedEmptyCell = true;
                if (BigInteger.Parse(input[mollyStartPos].ToString()) == 0)
                {
                    mollyReachedEmptyCell = true;
                }
                else
                {
                    currentMollyFlowers = BigInteger.Parse(input[mollyStartPos].ToString());
                    mollyResult += currentMollyFlowers;
                }
                break;
            }
            //result
            if (mollyStartPos != dollyStartPos)
            {
                currentMollyFlowers = BigInteger.Parse(input[mollyStartPos].ToString());
                currentDollyFlowers = BigInteger.Parse(input[dollyStartPos].ToString());

                int tempPosMolly = mollyStartPos;
                int tempPosDolly = dollyStartPos;

                //next position
                mollyStartPos = (int)((mollyStartPos + BigInteger.Parse(input[mollyStartPos])) % input.Length);
                dollyStartPos = (int)((dollyStartPos - BigInteger.Parse(input[dollyStartPos])) % input.Length);
                if (dollyStartPos < 0)
                {
                    dollyStartPos += input.Length;
                }

                input[tempPosMolly] = "0";
                input[tempPosDolly] = "0";

                mollyResult += currentMollyFlowers;
                dollyResult += currentDollyFlowers;
            }
            else
            {
                BigInteger currentScoreInCell = BigInteger.Parse(input[mollyStartPos]);
                if (currentScoreInCell == 1)
                {
                    input[mollyStartPos] = "0";
                    break;
                }

                currentMollyFlowers= currentScoreInCell / 2;
                currentDollyFlowers= currentScoreInCell / 2;

                int tempPosMolly = mollyStartPos;
                int tempPosDolly = dollyStartPos;

                //next position
                mollyStartPos = (int)((mollyStartPos + BigInteger.Parse(input[mollyStartPos])) % input.Length);
                dollyStartPos = (int)((dollyStartPos - BigInteger.Parse(input[dollyStartPos])) % input.Length);
                if (dollyStartPos < 0)
                {
                    dollyStartPos += input.Length;
                }

                if (BigInteger.Parse(input[mollyStartPos]) % 2 != 0)
                {
                    input[mollyStartPos] = "1";
                }
                else
                {
                    input[mollyStartPos] = "0";
                }

                input[tempPosMolly] = "0";

                mollyResult += currentMollyFlowers;
                dollyResult += currentDollyFlowers;
            }
        }
        if (mollyReachedEmptyCell == dollyReachedEmptyCell)
        {
            Console.WriteLine("Draw");
            Console.WriteLine("{0} {1}", mollyResult, dollyResult);
        }
        else if (mollyReachedEmptyCell)
        {
            Console.WriteLine("Dolly");
            Console.WriteLine("{0} {1}", mollyResult, dollyResult);

        }
        else
        {
            Console.WriteLine("Molly");
            Console.WriteLine("{0} {1}", mollyResult, dollyResult);
        }
    }
}

