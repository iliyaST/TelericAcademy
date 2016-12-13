
namespace StringBuilderSubstringExtensionMethods
{
    using System;
    using System.Text;

    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Create Extension method with 2 parameters witch we will applay for all variables of type StringBuilder
        /// </summary>
        /// <param name="input">We declare we want to extend some variable (input) of type StringBuilder</param>
        /// <param name="startIndex">The start index</param>
        /// <param name="lenght">The lenght of the Substring (is the same as String.Substring) </param>
        /// <returns>Our substring</returns>
        public static StringBuilder Substring(this StringBuilder input,int startIndex,int lenght)
        {
            if (startIndex < 0 || startIndex >= input.Length || startIndex + lenght > input.Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                //return new sringbuilder as substring of the input
                StringBuilder output = new StringBuilder();

                for (int i = startIndex; i < startIndex + lenght; i++)
                {
                    output.Append(input[i]);
                }

                return output;
            }
        }

        /// <summary>
        /// Create extension for StringBuilder that counts how many times we have single letter in it...
        /// </summary>
        /// <param name="input"></param>
        /// <param name="letter"></param>
        /// <returns>Returns the number of occurances of the letter we choose</returns>
        public static int CountSomeLetter(this StringBuilder input,char letter)
        {
            int countTheOccurancesOfTheLetter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == letter)
                {
                    countTheOccurancesOfTheLetter++;
                }
            }

            return countTheOccurancesOfTheLetter;
        }
    }
}
