namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
       public static void Main()
        {
            Console.WriteLine(FileExtensionMethods.GetFileExtension("example"));
            Console.WriteLine(FileExtensionMethods.GetFileExtension("example.pdf"));
            Console.WriteLine(FileExtensionMethods.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileExtensionMethods.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileExtensionMethods.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileExtensionMethods.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", Distance.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", Distance.CalcDistance3D(5, 2, -1, 3, -6, 4));

            FigureGeometry.Width = 3;
            FigureGeometry.Height = 4;
            FigureGeometry.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", FigureGeometry.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", FigureGeometry.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", FigureGeometry.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", FigureGeometry.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", FigureGeometry.CalcDiagonalYZ());
        }
    }
}
