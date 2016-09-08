using System;
using System.Text;
/*
Problem 8. Isosceles Triangle
Write a program that prints an isosceles triangle of 9 copyright symbols ©, something like this:
©

© ©

©   ©

© © © ©
Note: The © symbol may be displayed incorrectly at the console so you may need to 
change the console character encoding to UTF-8 and assign a Unicode-friendly font in the console.
Note: Under old versions of Windows the © symbol may still be displayed incorrectly, 
regardless of how much effort you put to fix it.
*/
class IsoscelesTriangle
{
    static void Main()
    {
        Encoding enc = new UTF8Encoding(true, true);
        string var1 = "   ©";
        string var2 = "  © ©";
        string var3 = " © © ©";
        string var4 = "© © © ©";
        Console.WriteLine(var1);
        Console.WriteLine(var2);
        Console.WriteLine(var3);
        Console.WriteLine(var4);
        String var5 = "   ©\n  © ©\n © © ©\n© © © ©";
        Console.WriteLine(var5);
        Console.WriteLine("   ©\n  © ©\n © © ©\n© © © ©");

    }
}

