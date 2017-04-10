namespace MatrixFullFillment
{
    using MatrixFullFIllment.Contracts;
    using System;

    public class Engine
    {
        private ILogger logger;

        public Engine(string matrixDimensions, ILogger logger)
        {
            this.MatrixDimensions = matrixDimensions;
            this.logger = logger;
        }

        public string MatrixDimensions { get; set; }

        public int[,] Execute()
        {
            int matrixDimensions;

            while (!int.TryParse(this.MatrixDimensions, out matrixDimensions) || matrixDimensions <= 0 || matrixDimensions > 100)
            {
                this.logger.Log("You haven't entered a correct positive number!");
                this.logger.Log("Default value will be used...");

                matrixDimensions = 3;
                break;
            }

            var matrix = new QadraticMatrix(matrixDimensions);

            matrix.FillMatrixRotatingWalkStyle();

            MatrixActions.PrintMatrix(matrix.Body);

            return matrix.Body;
        }
    }
}
