
namespace FindLongestString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MaximumLengthOfString
    {
        static void Main()
        {
            // Create string array
            string[] words = new string[]
            {
                "lksadjkasd",
                "a2df",
                "adfgfhg,.lkj",
                "adsddf",
                "lksadjrggsxcvxkasd",
                "cxzcxzvcxgrsg",
                "asdz",
                "zz",
                "LongestLongestLongestLongestLongestLongest",
                "asdasd",
            };

            var longestWord =
            (from word in words
             orderby word.Length
             select word).Last();

            Console.WriteLine(longestWord);
        }
    }
}
