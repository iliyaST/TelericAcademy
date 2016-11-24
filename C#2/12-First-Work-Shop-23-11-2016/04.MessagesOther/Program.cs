using System;

class MessagesOther
{
    static string ConvertToDecimal(string text)
    {
        string result = "";
        int counter = 0;
        string decSum = "";
        //cadxoz

        for (int i = 0; i < text.Length + 1; i++)
        {
            if (counter == 3)
            {
                switch (result)
                {
                    case "cad": decSum += "0"; break;
                    case "xoz": decSum += "1"; break;
                    case "nop": decSum += "2"; break;
                    case "cyk": decSum += "3"; break;
                    case "min": decSum += "4"; break;
                    case "mar": decSum += "5"; break;
                    case "kon": decSum += "6"; break;
                    case "iva": decSum += "7"; break;
                    case "ogi": decSum += "8"; break;
                    case "yan": decSum += "9"; break;
                }
                result = "";
                counter = 0;
            }
            if (i == text.Length)
            {
                break;
            }
            result += text[i]; //cad
            counter++;
        }

        return decSum;
    }

    static void Main()
    {
        //enter firstWord
        string firstWord = Console.ReadLine();
        //enter operation + or -
        string operation = Console.ReadLine();
        //enter secondWord
        string secondWord = Console.ReadLine();

        string convertedFirstWord = ConvertToDecimal(firstWord);
        string convertedSecondWord = ConvertToDecimal(secondWord);

        int result = 0;

        if (operation == "+")
        {
            result = int.Parse(convertedFirstWord) + int.Parse(convertedSecondWord);
        }
        else
        {
            result = int.Parse(convertedFirstWord) - int.Parse(convertedSecondWord);
        }

        string resulted = "";

        while (result > 0)
        {
            switch (result % 10)
            {
                case 0: resulted = "cad" + resulted; break;
                case 1: resulted = "xoz" + resulted; break;
                case 2: resulted = "nop" + resulted; break;
                case 3: resulted = "cyk" + resulted; break;
                case 4: resulted = "min" + resulted; break;
                case 5: resulted = "mar" + resulted; break;
                case 6: resulted = "kon" + resulted; break;
                case 7: resulted = "iva" + resulted; ; break;
                case 8: resulted = "ogi" + resulted; break;
                case 9: resulted = "yan" + resulted; break;
            }
            result /= 10;
        }
        Console.WriteLine(resulted);
    }
}

