using System;
using System.IO;

class ReadFileContents
{
    static void Main()
    {
        string path = Console.ReadLine();
        string readText = String.Empty;

        try
        {
           readText = File.ReadAllText(path);           
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("The path is null");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Path contains invalid chars or contains blank spaces");
        }
        catch(PathTooLongException)
        {
            Console.WriteLine("Path is longer than system predefined.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Such directory does not exist or cant be found!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The File can not be found.");
        }
        catch (IOException)
        {
            Console.WriteLine("I/O error!");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Restricted permission");
        }
        catch(NotSupportedException)
        {
            Console.WriteLine("File is not supported!");
        }


        Console.WriteLine(readText);
    }
}

