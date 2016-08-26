using System;
/*
Problem 2. Float or Double?
Which of the following values can be assigned to a variable of type 
float and which to a variable of type double: 34.567839023, 12.345, 8923.1234857, 3456.091
Write a program to assign the numbers in variables and print them to ensure no precision is lost
*/
class FloatorDouble
{
    static void Main()
    {
        float variable1 = 12.345f;
        float variable2 = 3456.091f;
        double variable3 = 34.567839023;
        double variable4 = 8923.1234857;

        Console.Write(variable1 + ", " + variable2 + ", " + variable3 + ", " + variable4 + "\n");

    }
}
