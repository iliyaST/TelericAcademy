
namespace StringBuilderSubstringExtensionMethods
{
    using System;
    using System.Text;

    public class StringBuilderTest
    {
        public static void Main()
        {
            //We create some substring and fill it with something
            StringBuilder sb = new StringBuilder();
            sb.Append("Hello World!");
            //We use our method on it and save it to the variable ourSubstring
            string ourSubstring = sb.Substring(1, 3).ToString();
            //Print the variable ourSubstring
            Console.WriteLine(ourSubstring);

            //Use another extension we created to count how many times we see the letter "o" in our string.
            Console.WriteLine("Enter the letter you want to look for...in \"Hello World!\"");
            char letter = char.Parse(Console.ReadLine());
            int countOccurances = sb.CountSomeLetter(letter);
            //the occurances of o in Hello World are 2.....
            Console.WriteLine("the occurances of ( \"{0}\" ) \"in Hello World\" are {1}...", letter, countOccurances);
        }
    }
}
