using System;
using System.IO;
using System.Net;

class DownloadFileFromNet
{
    static void Main()
    {
        Console.Write("Enter URL of file: ");
        string url = Console.ReadLine();
        Console.Write("Enter saved file name: ");
        string myFile = Console.ReadLine();
        Console.WriteLine("\n\rDownloading file. Please wait...");

        try
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(url, myFile);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You do not have permission to current directory.");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Your OS does not support GetCurrentDirectory().");
        }
        catch (WebException)
        {
            Console.WriteLine("Your URL is not valid.");
        }
        finally
        {
            Console.WriteLine("\n\rThank you for using this simple downloader! :) \n\rIf you like this program, please donate for a beer: PoorCSharpCoder@Paypal.com\n\r");
        }
    }
}