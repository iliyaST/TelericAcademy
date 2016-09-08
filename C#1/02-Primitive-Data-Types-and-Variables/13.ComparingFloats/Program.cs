using System;
/*
Problem 13.* Comparing Floats
Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001.
Note: Two floating-point numbers a and b cannot be compared directly by a == b because of the nature of the 
floating-point arithmetic. Therefore, we assume two numbers are equal if they are more closely to each other 
than a fixed constant eps.
5.3	6.01	false	The difference of 0.71 is too big (> eps)
5.00000001	5.00000003	true	The difference 0.00000002 < eps
5.00000005	5.00000001	true	The difference 0.00000004 < eps
-0.0000007	0.00000007	true	The difference 0.00000077 < eps
-4.999999	-4.999998	false	Border case. The difference 0.000001 == eps. We consider the numbers are different.
4.999999	4.999998	false	Border case. The difference 0.000001 == eps. We consider the numbers are different.
*/
class ComparingFloats
{
    static void Main()
    {
        float eps = 0.000001f;
        Console.WriteLine("Please insert the first number:");
        double member1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Please insert the second number:");
        double member2 = double.Parse(Console.ReadLine());
        float member3 = (float)(member1 - member2);
        if (member3 < 0)
        {
            member3 = member3 * -1;
        }
        Console.WriteLine("The difference is: " + member3);
        if (member3 >= eps)
        {
            Console.WriteLine("The numbers are different!");
        }
        if (member3 < eps)
        {
            Console.WriteLine("The numbers are equal!");
        }
    }
}
