using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CryptoCS
{
    class CryproCS
    {    

        static void Main()
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string text = Console.ReadLine();
            char operat = char.Parse(Console.ReadLine());
            string number = Console.ReadLine();
            BigInteger index = 0;
            BigInteger sum = 0;
            BigInteger sum2 = 0;
            BigInteger result = 0;
            string resultStr = String.Empty;
            string res = String.Empty;

            int pow = text.Length - 1;

            for (int i = 0; i <= text.Length - 1; i++)
            {
                for (int j = 0; j <= alphabet.Length - 1; j++)
                {
                    if (text[i] == alphabet[j])
                    {
                        sum += j * BigInteger.Pow(26, pow);
                        pow--;
                        break;
                    }
                }
            }

            for (int i = 0; i <= number.Length - 1; i++)
            {
                sum2 += (number[i] - '0') * BigInteger.Pow(7, number.Length - 1 - i);
            }

            if (operat == '+')
            {
                result = sum + sum2;
            }
            else if (operat == '-')
            {
                result = sum - sum2;
            }
            resultStr = result.ToString();
            while (result > 0)
            {
                res += result % 9;
                result = result / 9;
            }
            char[] reversedResult = res.ToArray();
            Array.Reverse(reversedResult);
            Console.Write(String.Join("", reversedResult));
        }
    }
}