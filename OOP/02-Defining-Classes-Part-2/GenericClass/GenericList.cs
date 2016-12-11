using System;
using System.Text;

namespace Generic
{
    public class GenericList<T> where T : IComparable
    {
        /// <summary>
        /// List of T elements
        /// </summary>
        private T[] list;
        private int currentElement = 0;

        /// <summary>
        /// Constructor with capacity
        /// </summary>
        /// <param name="capacity">The capacity of the list</param>
        public GenericList(int capacity)
        {
            list = new T[capacity];
        }

        /// <summary>
        ///Create Method for adding elements in the array 
        /// </summary>
        /// <param name="value">Current value</param>
        public void AddElement(T value)
        {
            if (currentElement == list.Length)
            {
                DoubleCapacity();
            }

            list[currentElement] = value;
            currentElement++;
        }

        /// <summary>
        /// Make our array (list) accesable by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>the value of the element on the position we want (index) </returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= currentElement)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return list[index];
                }
            }
            set
            {
                if (index < 0 || index >= currentElement)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    list[index] = value;
                }
            }
        }

        /// <summary>
        /// Removing element from the Array of T elements
        /// </summary>
        /// <param name="index">The position of the element we want to remove</param>
        public void RemoveElement(int index)
        {
            if (index < 0 || index >= list.Length)
            {
                throw new ArgumentOutOfRangeException("Index is out of range of our array");
            }
            else
            {
                T[] newList = new T[list.Length];

                for (int i = 0; i < index; i++)
                {
                    newList[i] = list[i];
                }

                for (int i = index + 1; i < currentElement; i++)
                {
                    newList[i] = list[i];
                }

                list = newList;
                currentElement--;
            }
        }

        /// <summary>
        ///  Inserts element on current position
        /// </summary>
        /// <param name="possition">The position we want to insert element on.</param>
        /// <param name="value">The element we want to insert.</param>
        public void InsertElement(int possition, T value)
        {
            if (currentElement == list.Length)
            {
                DoubleCapacity();
            }

            if (possition < 0 || possition > currentElement)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                T[] newArray = new T[list.Length];

                for (int i = 0; i < possition; i++)
                {
                    newArray[i] = list[i];
                }

                newArray[possition] = value;

                for (int i = possition + 1; i < currentElement; i++)
                {
                    newArray[i] = list[i];
                }

                list = newArray;
                currentElement++;
            }
        }

        /// <summary>
        ///  Clears the list
        /// </summary>
        public void ClearList()
        {
            list = new T[0];
            currentElement = 0;
        }

        /// <summary>
        /// Finds Element by its value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">Value we are looking for</param>
        /// <returns>-1 if there is no such element</returns>
        public int FindElement(T value)
        {
            int index = -1;

            for (int i = 0; i < currentElement; i++)
            {
                if (value.Equals(list[i]))
                {
                    return i;
                }
            }

            return index;
        }

        /// <summary>
        /// Doubles the capacity of the list
        /// </summary>
        public void DoubleCapacity()
        {
            T[] newArray = new T[list.Length * 2];

            for (int i = 0; i < list.Length; i++)
            {
                newArray[i] = list[i];
            }

            list = newArray;
        }


        /// <summary>
        /// Find the smallest value in the list (first make it list of elements with only comaparable elements)
        /// (Where T : IComparable)
        /// </summary>
        /// <returns>Returns the smalles element in the list.</returns>
        public T MinElement()
        {
            T minValue = list[0];

            for (int i = 1; i < list.Length; i++)
            {
                if (minValue.CompareTo(list[i]) <= 0)
                {
                    minValue = list[i + 1];
                }
            }

            return minValue;
        }

        /// <summary>
        /// Analogic with min value 
        /// </summary>
        /// <returns>Returns max value in the list</returns>
        public T MaxValue()
        {
            T maxValue = list[0];

            for (int i = 1; i < currentElement; i++)
            {
                if (maxValue.CompareTo(list[i]) > 0)
                {
                    maxValue = list[i];
                }
            }

            return maxValue;
        }

        /// <summary>
        /// Finds the lists Count
        /// </summary>
        public int Count
        {
            get { return currentElement; }
        }

        /// <summary>
        /// Overide toString
        /// </summary>
        /// <returns>All the elements</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < currentElement; i++)
            {
                output.Append(list[i] + " ");
            }

            output.AppendLine();

            return output.ToString();
        }

    }
}
