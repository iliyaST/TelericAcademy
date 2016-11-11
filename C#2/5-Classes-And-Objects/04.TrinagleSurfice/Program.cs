using System;

class TrinagleSurfice
{
    static double CalculateSurficeBySideAndAltitude(double side, double altitude)
    {
        double surfice = (side * altitude) / 2;

        return surfice;
    }
    static double CalculateSurficeByThreeSides(double firstside, double secondside, double thirdside)
    {
        double p = (firstside + secondside + thirdside) / 2;

        double surfice = Math.Sqrt(p * (p - firstside) * (p - secondside) * (p - thirdside));

        return surfice;
    }
    static double CalculateSurficeByTwoSidesAndGivenAngle(double firstside, double secondside, double angle)
    {
        double angleInRadians = (angle * Math.PI) / 180;

        double surfice = (firstside * secondside * Math.Sin(angleInRadians)) / 2;

        return surfice;
    }

    static void Main()
    {
        Console.WriteLine("Enter 3sides, altitude and angle between first 2 sides");
        double firstSide = double.Parse(Console.ReadLine());
        double secondSide = double.Parse(Console.ReadLine());
        double thirdSide = double.Parse(Console.ReadLine());
        double altitude = double.Parse(Console.ReadLine());
        double angle = double.Parse(Console.ReadLine());

        double surficeWithAngle = CalculateSurficeByTwoSidesAndGivenAngle(firstSide, secondSide, angle);
        double surficeWithALtitude = CalculateSurficeBySideAndAltitude(firstSide, altitude);
        
        double surficeWithSides = CalculateSurficeByThreeSides(firstSide, secondSide, thirdSide);

        //Cout surfice With 2 sides and Angle
        Console.WriteLine("{0:F2}", surficeWithAngle);
    }
}

