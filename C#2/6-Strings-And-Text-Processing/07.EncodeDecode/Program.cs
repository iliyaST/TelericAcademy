using System;
using System.Text;

class EncodeDecode
{
    static StringBuilder encryptTheText(string message,string cipher)
    {
        StringBuilder encode = new StringBuilder();

        for (int i = 0; i < message.Length; i++)
        {
            encode.Append((char)(message[i] ^ cipher[i % cipher.Length]));
        }

        return encode;
    }

    static void Main()
    {
        string text = Console.ReadLine();
        string key = "ab";

        StringBuilder encrypt = encryptTheText(text, key);        

        Console.WriteLine(encrypt);

        string encryptText = encrypt.ToString();

        foreach (var ch in encrypt.ToString())
        {
            // print the result of encryption as a series of Unicode escape characters \xxxx
            Console.Write("\\u{0:x4}", (int)ch);
        }


        StringBuilder decryption = encryptTheText(encryptText, key);

        Console.WriteLine(decryption);
    }
}

