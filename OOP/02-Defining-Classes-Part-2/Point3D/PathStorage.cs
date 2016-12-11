using System;
using System.IO;

namespace Point3D
{
    static class PathStorage
    {
        private static readonly StreamReader reader = new StreamReader(@"..\..\input.txt");
        private static readonly StreamWriter writer = new StreamWriter(@"..\..\output.txt");


        /// <summary>
        /// Load coordinate from the current input.txt file into a new object from Path that we create
        /// </summary>
        /// <returns>The method returns the object filled with cooridantes (if there are any)</returns>
        public static Path LoadFile()
        {
            Path currentPath = new Path();

            using (reader)
            {
                string currentLine = reader.ReadLine();

                while (currentLine != null)
                {
                    string[] nubersOnCurrentLine = currentLine.Split(' ');

                    int x = int.Parse(nubersOnCurrentLine[0]);
                    int y = int.Parse(nubersOnCurrentLine[1]);
                    int z = int.Parse(nubersOnCurrentLine[2]);

                    Point3DCoordinates currentPoint = new Point3DCoordinates(x, y, z);

                    currentPath.AddPoint(currentPoint);

                    currentLine = reader.ReadLine();
                }
            }

            return currentPath;
        }

        public static void SaveFile(Path currentPath)
        {
            using (writer)
            {
                foreach (var item in currentPath.points)
                {
                    string currentLineToBeWriten = item.ToString();
                    writer.WriteLine(currentLineToBeWriten);
                }
            }
        }
    }
}
