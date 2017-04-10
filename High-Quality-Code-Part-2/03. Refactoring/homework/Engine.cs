namespace FillMatrixTest
{
    using QuadraticMatrixCreation;
    using MatrixActions;

    public class MatrixActionsTest
    {
        public static void Main(string[] args)
        {
            // Console.WriteLine( "Enter a positive number " );
            // string input = Console.ReadLine(  );
            // int n = 0;
            // while ( !int.TryParse( input, out n ) || n < 0 || n > 100 )
            // {
            //    Console.WriteLine( "You haven't entered a correct positive number" );
            //    input = Console.ReadLine(  );
            // }
            int dimensions = 3;

            var matrix = new QadraticMatrix(dimensions);

            matrix.FillMatrix();

            MatrixActions.PrintMatrix(matrix.Body);
        }
    }
}
