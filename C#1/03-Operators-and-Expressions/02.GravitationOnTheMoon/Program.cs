using System;
/*
Problem 2. Gravitation on the Moon
The gravitational field of the Moon is approximately 17% of that on the Earth.
Write a program that calculates the weight of a man on the moon by a given weight on the Earth. 
*/
class GravitationOnTheMoon
{
    static void Main()
    {
        double weight = double.Parse(Console.ReadLine());
        double weightOnTheMoon = 17.0 / 100 * weight;
        Console.WriteLine("{0:0.000}",weightOnTheMoon);

    }
}

