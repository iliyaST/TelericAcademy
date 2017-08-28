using System;
using System.Collections.Generic;
using System.Linq;

namespace Frames
{
    public class Program
    {
        private static int n;
        private static Tuple<int, int>[] list;
        private static SortedSet<string> result;
        private static int count = 0;

        public static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());

            list = new Tuple<int, int>[n];
            result = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var currentSize = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                var parsedCurrentSize = new Tuple<int, int>(currentSize[0], currentSize[1]);

                list[i] = parsedCurrentSize;
            }

            Perm(list, 0);

            Console.WriteLine(result.Count);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static void Perm(Tuple<int, int>[] arr, int k)
        {
            if (k >= arr.Length)
            {
                count++;
                result.Add(string.Join<Tuple<int, int>>(" | ", arr));
                return;
            }
            else
            {
                Perm(arr, k + 1);
                SwapElement(ref arr[k]);
                Perm(arr, k + 1);
                SwapElement(ref arr[k]);

                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);

                    Perm(arr, k + 1);
                    SwapElement(ref arr[k]);
                    Perm(arr, k + 1);
                    SwapElement(ref arr[k]);

                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        private static void Swap(ref Tuple<int, int> first, ref Tuple<int, int> second)
        {
            Tuple<int, int> oldFirst = first;
            first = second;
            second = oldFirst;
        }

        private static void SwapElement(ref Tuple<int, int> element)
        {
            int first = element.Item1;
            int second = element.Item2;

            var newElement = new Tuple<int, int>(second, first);

            element = newElement;
        }
    }
}
