
namespace RangeExeptions
{
    using System;

    /// <summary>
    /// The exception that is thrown when an input argument is not in range.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InvalidRangeException<T> : ApplicationException
        where T : IComparable<T>
    {
        public T Start { get; private set; }
        public T End { get; private set; }

        /// <summary>
        /// Initializes new instance of InvalidRangeExeption class.
        /// </summary>
        /// <param name="start">Lower bound of the range.</param>
        /// <param name="end">Upper bound of the range.</param>
        public InvalidRangeException(T start, T end)
        {
            this.Start = start;
            this.End = end;
        }

        /// <summary>
        /// Gets the string message representation of the occured error.
        /// </summary>
        public override string Message
        {
            get
            {
                return string.Format("Value cannot be outside the range {0} and {1}.", this.Start, this.End);
            }
        }   
    }
}
