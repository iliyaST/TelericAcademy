using System;
using System.Collections.Generic;
using System.Linq;

namespace Frames
{
    public class Program
    {
        private static int n;
        private static IList<Frame> list;
        private static SortedSet<string> result;
        private static int id = 0;

        public static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());

            list = new List<Frame>();
            result = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                id++;
                var currentSize = Console.ReadLine().Split(' ');
                var size1 = int.Parse(currentSize[0]);
                var size2 = int.Parse(currentSize[1]);
                var parsedCurrentSize = new Frame(size1, size2);

                if (parsedCurrentSize.Width == parsedCurrentSize.Height)
                {
                    list.Add(parsedCurrentSize);
                    continue;
                }

                list.Add(parsedCurrentSize);
                ReverseSize(ref parsedCurrentSize);
                list.Add(parsedCurrentSize);
            }

            GenerateVariationsNoRepetitions(0, new bool[list.Count], new List<Frame>());

            Console.WriteLine(result.Count);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static void GenerateVariationsNoRepetitions(int index, bool[] used, List<Frame> currentList)
        {
            if (currentList.Count >= n)
            {
                result.Add(string.Join(" | ", currentList));
                return;
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (currentList.Count == 0)
                    {
                        used = new bool[list.Count];
                        if (i - 1 >= 0 && list[i].ID == list[i - 1].ID)
                        {
                            continue;
                        }
                    }

                    if (!used[i])
                    {
                        used[i] = true;
                        if (i - 1 >= 0 && list[i - 1].ID == list[i].ID)
                        {
                            used[i - 1] = true;
                        }
                        else if (i + 1 < list.Count && list[i].ID == list[i + 1].ID)
                        {
                            used[i + 1] = true;
                        }

                        currentList.Add(list[i]);

                        GenerateVariationsNoRepetitions(index + 1, used, currentList);

                        currentList.Remove(list[i]);

                        if (i - 1 >= 0 && list[i - 1].ID == list[i].ID)
                        {
                            used[i - 1] = false;
                        }
                        else if (i + 1 < list.Count && list[i + 1].ID == list[i].ID)
                        {
                            used[i + 1] = false;
                        }

                        used[i] = false;
                    }
                }
            }
        }

        static void ReverseSize(ref Frame size)
        {
            var item1 = size.Width;
            var item2 = size.Height;

            var newTuple = new Frame(item2, item1);

            size = newTuple;
        }

        public class Frame
        {
            public Frame(int width, int height)
            {
                this.Width = width;
                this.Height = height;
                this.ID = id;
            }

            public int Width { get; set; }

            public int Height { get; set; }

            public int ID { get; set; }

            public override string ToString()
            {
                return string.Format("({0}, {1})", this.Width, this.Height);
            }
        }
    }
}
