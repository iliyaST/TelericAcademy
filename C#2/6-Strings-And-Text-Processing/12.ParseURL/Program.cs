using System;

class ParseURL
{
    static void Main()
    {
        string url = Console.ReadLine();
        int index = 0;

        index = url.IndexOf("://", index);

        string protocol = url.Substring(0, index);

        index += 3;

        int serverIndex = index;

        index = url.IndexOf("/", index);

        string server = url.Substring(serverIndex, index - serverIndex);

        string resource = url.Substring(index, url.Length - index);

        Console.WriteLine("[protocol] = {0}", protocol);
        Console.WriteLine("[server] = {0}", server);
        Console.WriteLine("[resource] = {0}", resource);

    }
}

