using System;
using System.Threading;

namespace DelegatesAndTimerClass
{

    /// <summary>
    /// Simple delegate without parameters and return value.
    /// </summary>
    public delegate void SimpleDelegate();

    class Timer
    {
        /// <summary>
        /// Repeats delegated functions.
        /// </summary>
        /// <param name="handler">Delegated function.</param>
        /// <param name="time">Repeat time.</param>
        public void Start(SimpleDelegate handler, int time)
        {
            // New thread for anonymous method that initiates infinite loop.
            Thread NotControlledThread = new Thread(delegate ()
            {
                while (true)
                {
                    // Delegated method call
                    handler();

                    // Sleeps the thread for user specified time
                    Thread.Sleep(time * 1000);
                }
            });

            // Start the new thread
            NotControlledThread.Start();

            // Wait for user input to stop the thread.
            Console.WriteLine("Press enter key to stop!");
            Console.ReadLine();

            // Stop thread
            NotControlledThread.Abort();
        }
    }
}