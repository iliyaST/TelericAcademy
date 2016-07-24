using System;
/*
Problem 12. Null Values Arithmetic
Create a program that assigns null values to an integer and to a double variable.
Try to print these variables at the console.
Try to add some number or the null literal to these variables and print the result.
*/

class NullValuesArithmetic
{
    static void Main()
    {
        int? variable1 = null;
        double? variable2 = null;
        Console.WriteLine("variable1 = {0} \nvariable2 = {1}", variable1, variable2);
        variable1 += 1;
        variable2 += null;
        Console.WriteLine("variable1 = {0} \nvariable2 = {1}", variable1, variable2);



    }
}

