namespace MatrixFullFillment
{
    using System;
    using MatrixFullFIllment.Contracts;
  
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
