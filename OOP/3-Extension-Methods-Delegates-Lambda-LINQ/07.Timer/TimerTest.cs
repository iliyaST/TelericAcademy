/* 
 * Using delegates write a class Timer that 
 * has can execute certain method at each t seconds.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndTimerClass
{
    class TimerTest
    {
        static void Main()
        {
            // New delegate instance
            SimpleDelegate printingMethods = new SimpleDelegate(PrintCurrentDateTime);
            // Add method to delegate instance
            printingMethods += PrintSeparator;

            // New timer instance
            Timer newTimer = new Timer();

            // Start executing provided methods in 1 second interval
            newTimer.Start(printingMethods, 1);
        }

        /// <summary>
        /// Prints current datetime
        /// </summary>
        public static void PrintCurrentDateTime()
        {
            Console.WriteLine(DateTime.Now);
        }

        /// <summary>
        /// Prints separator
        /// </summary>
        public static void PrintSeparator()
        {
            Console.WriteLine(new string('-', 20));
        }
    }
}