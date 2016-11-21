using System;
using System.Text;

class DecodeAndDecrypt
{
    static string EncryptOrDecrypt(string message, string cypher)
    {
        int cypherLen = cypher.Length;
        string messageOrCypher = "";
        int index = 0;

        if (message.Length >= cypher.Length)
        {
            for (int i = 0; i < message.Length; i++)
            {
                if (index == cypherLen)
                {
                    index = 0;
                }
                char tempBit = (char)(message[i] - 65 ^ cypher[index] - 65);
                messageOrCypher += (char)(tempBit + 'A');
                index++;
            }
        }
        else
        {
            int lenDifference = cypher.Length - message.Length;
            int counter = 0;
            bool counterIsEnd = false;

            for (int i = 0; i < message.Length; i++)
            {
                if (counterIsEnd == true)
                {
                    char tempBit = (char)(message[i] - 65 ^ cypher[i] - 65);
                    messageOrCypher += (char)(tempBit + 'A');
                }
                else
                {
                    if (counter >= lenDifference)
                    {
                        char tempBit = (char)(message[i] - 65 ^ cypher[i] - 65);
                        messageOrCypher += (char)(tempBit + 'A');
                        counterIsEnd = true;
                        continue;
                    }
                    char tempBit1 = (char)(message[i] - 65 ^ cypher[i] - 65);
                    char tempBit2 = (char)(tempBit1 ^ cypher[cypher.Length - lenDifference + counter] - 65);
                    messageOrCypher += (char)(tempBit2 + 'A');
                    counter++;
                }
            }
        }
        return messageOrCypher;
    }
    static string Decode(string text)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            if (Char.IsDigit(text[i]))
            {
                string countRepeats = "";
                int index = i;

                while (Char.IsDigit(text[index]))
                {
                    countRepeats += text[index];
                    index++;
                }

                int countR = int.Parse(countRepeats);

                sb.Append(text[i + countRepeats.Length], countR);
                i+=countRepeats.Length;
                continue;
            }
            else
            {
                sb.Append(text[i]);
            }
        }
        return sb.ToString();
    }

    static void Main()
    {
        string message = Console.ReadLine();

        //get last cypherlength
        var sb = new StringBuilder();
        string lenInString = "";

        for (int i = message.Length - 1; i >= 0; i--)
        {
            if (Char.IsDigit(message[i]))
            {
                sb.Append(message[i]);
            }
            else
            {
                break;
            }
            lenInString = sb.ToString() + lenInString;
            sb.Clear();
        }
        //get cypher length
        int cypherLen = int.Parse(lenInString);
        //get messaige without digits
        string messageWithouthLastChar = message.Substring(0, message.Length - lenInString.Length);
        //encode the message without last char
        string resultDecode = Decode(messageWithouthLastChar);
        //substract the cypher and encryptedMessage from the encrypted message
        string cypher = resultDecode.Substring(resultDecode.Length - cypherLen, cypherLen);
        string encryptedMessage = resultDecode.Substring(0, resultDecode.Length - cypher.Length);
        //decrypt message
        string result = EncryptOrDecrypt(encryptedMessage, cypher);
        //print result
        Console.WriteLine(result);
    }
}

