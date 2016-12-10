using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.Property
{
    class GSMCallHistoryTest
    {
        static void Main()
        {
            DateTime currentDate = DateTime.Now;
            DateTime firstDate = new DateTime(2016, 12, 3, 12, 34, 25);
            DateTime secondDate = new DateTime(2016, 12, 3, 6, 30, 0);

            Battery blackBerryBattery = new Battery("Li-Ion", 336, 26);
            Display blackBerryDisplay = new Display(5, 3686400);
            GSM phone = new GSM("DTEK60", "BlackBerry", 52900, "Mr.Smith", blackBerryBattery, blackBerryDisplay);

            Call firstCall = new Call(currentDate, "0876137474", 110);
            Call secondCall = new Call(firstDate, "0125125555", 2500);
            Call thirdCall = new Call(secondDate, "0123334566", 160);

            phone.AddCall(firstCall);
            phone.AddCall(secondCall);
            phone.AddCall(thirdCall);

            Call longestCall = new Call(DateTime.Now, "00000000", 0);
            long? maxCall = long.MinValue;

            foreach (var call in phone.callHistory)
            {
                Console.WriteLine("DateCall is: {0}.\nThe dialled number is: {1}.\nThe call endured: {2} seconds.\n",
                    call.DateTime, call.DialedNumber, call.Duration);

                if (call.Duration > maxCall)
                {
                    maxCall = call.Duration;
                    longestCall = call;
                }
            }

            //calculate price of Calls
            decimal? price = phone.CalculatePrice();
            Console.WriteLine("The price of all calls is: {0:F2}$.", price);

            //longestCall duratation
            Console.WriteLine(longestCall.Duration+"seconds.");
            //delete the longest Call
            phone.DeleteCall(longestCall);
            //Print the new total price of calls
            Console.WriteLine("The price of all calls without  the longest  is: {0:F2}$.", phone.CalculatePrice());
            //clear phone history
            phone.ClearHistory();
            Console.WriteLine("The price of all calls after clearing phone history is: {0:F2}$.", phone.CalculatePrice());
        }
    }
}
