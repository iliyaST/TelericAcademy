using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class CountWords
{
    static void Main()
    {
        try
        {
            StreamReader readerWords = new StreamReader(@"..\..\words.txt");

            using (readerWords)
            {
                string[] words = readerWords.ReadLine().Split(new char[] { ' ' });
            }

            StreamReader readText = new StreamReader(@"..\..\text.txt");

            StringBuilder separate = new StringBuilder();
            List<string> wordsFromText = new List<string>();

            using (readText)
            {
                string currentLine = readText.ReadLine();

                while (currentLine != null)
                {
                    for (int i = 0; i < currentLine.Length; i++)
                    {
                        if (Char.IsPunctuation(currentLine[i]))
                        {
                            separate.Append(currentLine[i]);
                        }
                    }

                    separate.Append((char)32);
                    string separator = separate.ToString();

                    string[] words = currentLine.Split(separator.ToCharArray(),
                        StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < words.Length; i++)
                    {
                        wordsFromText.Add(words[i]);
                    }

                    currentLine = readText.ReadLine();
                }
            }
            int counter = 0;


        }
        catch (OutOfMemoryException)
        {
            Console.WriteLine("Program runs out of memory.");
            return;
        }
        catch (IOException)
        {
            Console.WriteLine("File cannot be open.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Enlarging the value of this instance would exceed the max capacity.");
        }
        catch (ObjectDisposedException)
        {
            Console.WriteLine("Buffer is full.");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Contents of buffer cannot be written.");
        }
    }
}

