using System;
/*
Problem 6. Four-Digit Number
Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
Calculates the sum of the digits (in our example 2 + 0 + 1 + 1 = 4).
Prints on the console the number in reversed order: dcba (in our example 1102).
Puts the last digit in the first position: dabc (in our example 1201).
Exchanges the second and the third digits: acbd (in our example 2101).
The number has always exactly 4 digits and cannot start with 0.
*/
class FourDigitNumber
{
    static void Main()
    {
        short fourDigitNumber = short.Parse(Console.ReadLine());
        //a b c d are the fourDigitNumber's digits.
        int a = (fourDigitNumber / 1000) % 100;
        int b = (fourDigitNumber / 100) % 10;
        int c = (fourDigitNumber / 10) % 10;
        int d = fourDigitNumber % 10;
        
        int sumOfDigits = a + b + c + d;
        int reveresed = d * 1000 + c * 100 + b * 10 + a;
        int lastCharFirst = d * 1000 + a * 100 + b * 10 + c;
        int secondCharExchangeThird = a * 1000 + c * 100 + b * 10 + d;
        
        Console.WriteLine(sumOfDigits);
        if (b == 0 && c == 0 & d == 0)
        {
            Console.WriteLine("000{0}", reveresed);
        }
        else
        {
            if (c == 0 && d == 0)
            {
                Console.WriteLine("00{0}", reveresed);
            }
            else
            {
                if (d == 0)
                {
                    Console.WriteLine("0{0}", reveresed);
                }
                else
                {
                    Console.WriteLine(reveresed);
                }
            }
        }
            if ((lastCharFirst / 1000) % 100 == 0)
            {
                Console.WriteLine("0{0}", lastCharFirst);
            }
            else
            {
                Console.WriteLine(lastCharFirst);
            }
            if ((secondCharExchangeThird / 1000) % 100 == 0)
            {
                Console.WriteLine("0{0}", secondCharExchangeThird);
            }
            else
            {
                Console.WriteLine(secondCharExchangeThird);
            }

        }
    }

