namespace FillMatrixTest
{
    using System;
    using QuadraticMatrixCreation;
    using MatrixActions;  

    public class Engine
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive number ");

            string input = Console.ReadLine();

            int matrixDimensions = 0;

            while (!int.TryParse(input, out matrixDimensions) || matrixDimensions < 0 || matrixDimensions > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            int dimensions = matrixDimensions;

            var matrix = new QadraticMatrix(dimensions);

            matrix.FillMatrix();

            MatrixActions.PrintMatrix(matrix.Body);
        }
    }
}
